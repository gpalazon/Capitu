using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Capitu.Infra
{
    public static class HtmlHelperExtensions
    {
        private const string idsToReuseKey = "__htmlPrefixScopeExtensions_IdsToReuse_";

        public static MvcHtmlString RadioButtonListFor<TModel>(this HtmlHelper<TModel> helper, Expression<Func<TModel, bool?>> property, string trueLabel = "Ativo", string falseLabel = "Inativo", string htmlClass = "")
        {
            var html = new StringBuilder();

            string propertyName;
            object propertyValue;

            trueLabel = string.IsNullOrEmpty(trueLabel) ? "Ativo" : trueLabel;
            falseLabel = string.IsNullOrEmpty(falseLabel) ? "Inativo" : falseLabel;

            if (property.Body is MemberExpression)
            {
                propertyName = ((MemberExpression)property.Body).Member.Name;
                propertyValue = helper.ViewData.Model == null ? string.Empty : typeof(TModel).GetProperty(propertyName).GetValue(helper.ViewData.Model, null);
            }
            else
            {
                propertyName = helper.ViewData.ModelMetadata.PropertyName;
                propertyValue = helper.ViewData.Model;
            }

            htmlClass += " inputArrumado ";

            var radioTrueId = propertyName + "True";
            var radioFalseId = propertyName + "False";

            html.AppendFormat(@"<input type='radio' id='{0}' class='" + htmlClass + "' name='{1}' value='{2}' ", radioTrueId, propertyName, true);

            if (propertyValue != null && propertyValue.Equals(true))
                html.AppendLine("checked='checked' ");
            html.AppendFormat(" /> <label for='{0}' class='labelArrumado'>{1}</label>", radioTrueId, trueLabel);

            html.AppendFormat(@"<input type='radio' id='{0}' class='" + htmlClass + "' name='{1}' value='{2}' ", radioFalseId, propertyName, false);
            if (propertyValue != null && propertyValue.Equals(false))
                html.AppendLine("checked='checked' ");

            html.AppendFormat(" /> <label for='{0}' class='labelArrumado'>{1}</label>", radioFalseId, falseLabel);

            return new MvcHtmlString(html.ToString());
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property, Enum[] enums, string defaultValue = null, string @class = "")
        {
            var html = new StringBuilder();

            var type = typeof(TProperty);

            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }
            IList<string> names = new List<string>();
            foreach (var @enum in enums)
            {

                names.Add(@enum.GetType().GetEnumName(@enum));
            }

            var enumNames = names.ToArray();
            var enumValues = (from enumName in enumNames
                              let attributes = type.GetField(enumName).GetCustomAttributes(typeof(DescriptionAttribute), false)
                              select new SelectListItem
                              {
                                  Text = attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : enumName,
                                  Value = enumName
                              }).ToList();

            if (!string.IsNullOrEmpty(defaultValue)) enumValues.Insert(0, new SelectListItem { Text = defaultValue, Value = "" });

            html.Append(helper.DropDownListFor(property, enumValues, new { @class }).ToHtmlString());
            return new MvcHtmlString(html.ToString());

        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property, string defaultValue = null, string @class = "")
        {
            var html = new StringBuilder();

            var type = typeof(TProperty);

            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                type = Nullable.GetUnderlyingType(type);
            }

            var enumNames = type.GetEnumNames().ToArray();
            var enumValues = (from enumName in enumNames
                              let attributes = type.GetField(enumName).GetCustomAttributes(typeof(DescriptionAttribute), false)
                              select new SelectListItem
                              {
                                  Text = attributes.Length > 0 ? ((DescriptionAttribute)attributes[0]).Description : enumName,
                                  Value = enumName
                              }).ToList();

            if (!string.IsNullOrEmpty(defaultValue)) enumValues.Insert(0, new SelectListItem { Text = defaultValue, Value = "" });

            html.Append(helper.DropDownListFor(property, enumValues, new { @class }).ToHtmlString());
            return new MvcHtmlString(html.ToString());
        }

        public static MvcHtmlString DropDownListForEnum<TModel, TProperty>(this HtmlHelper<TModel> helper,
            Expression<Func<TModel, TProperty>> property, params Enum[] enums)
        {
            var html = new StringBuilder();

            var enumValues = enums.Select(
                @enum => new SelectListItem
                {
                    Text = @enum.GetEnumDescription(),
                    Value = Enum.GetName(@enum.GetType(), @enum)
                }).ToList();

            html.Append(helper.DropDownListFor(property, enumValues).ToHtmlString());
            return new MvcHtmlString(html.ToString());
        }

        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName)
        {
            var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
            string itemIndex = idsToReuse.Count > 0 ? idsToReuse.Dequeue() : Guid.NewGuid().ToString();

            // autocomplete="off" is needed to work around a very annoying Chrome behaviour whereby it reuses old values after the user clicks "Back", which causes the xyz.index and xyz[...] values to get out of sync.
            html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, html.Encode(itemIndex)));

            return BeginHtmlFieldPrefixScope(html, string.Format("{0}[{1}]", collectionName, itemIndex));
        }

        public static IDisposable BeginHtmlFieldPrefixScope(this HtmlHelper html, string htmlFieldPrefix)
        {
            return new HtmlFieldPrefixScope(html.ViewData.TemplateInfo, htmlFieldPrefix);
        }

        private static Queue<string> GetIdsToReuse(HttpContextBase httpContext, string collectionName)
        {
            // We need to use the same sequence of IDs following a server-side validation failure,  
            // otherwise the framework won't render the validation error messages next to each item.
            string key = idsToReuseKey + collectionName;
            var queue = (Queue<string>)httpContext.Items[key];
            if (queue == null)
            {
                httpContext.Items[key] = queue = new Queue<string>();
                var previouslyUsedIds = httpContext.Request[collectionName + ".index"];
                if (!string.IsNullOrEmpty(previouslyUsedIds))
                    foreach (string previouslyUsedId in previouslyUsedIds.Split(','))
                        queue.Enqueue(previouslyUsedId);
            }
            return queue;
        }

        private class HtmlFieldPrefixScope : IDisposable
        {
            private readonly TemplateInfo templateInfo;
            private readonly string previousHtmlFieldPrefix;

            public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
            {
                this.templateInfo = templateInfo;

                previousHtmlFieldPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
            }

            public void Dispose()
            {
                templateInfo.HtmlFieldPrefix = previousHtmlFieldPrefix;
            }
        }
    }
}
