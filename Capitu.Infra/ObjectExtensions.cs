using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Capitu.Infra
{
    public static class ObjectExtensions
    {
        public static string GetClassDisplayName(this object that)
        {
            return GetTypeDisplayName(that.GetType());
        }

        public static string GetTypeDisplayName(this Type type)
        {
            var displayName = type.Name;

            foreach (var customAttribute in type.GetCustomAttributes(true))
            {
                if (customAttribute is DisplayNameAttribute)
                {
                    displayName = (customAttribute as DisplayNameAttribute).DisplayName;
                }
            }

            return displayName;
        }

        public static string GetClassDescription(this object that)
        {
            return GetTypeDescription(that.GetType());
        }

        public static string GetTypeDescription(this Type type)
        {
            var descriptionName = type.Name;

            foreach (var customAttribute in type.GetCustomAttributes(true))
            {
                if (customAttribute is DescriptionAttribute)
                {
                    descriptionName = ( customAttribute as DescriptionAttribute ).Description;
                }
            }

            return descriptionName;
        }

        public static IEnumerable<Type> GetSubClasses(this Type type)
        {
            return type.Assembly.GetTypes().Where(p => type.IsAssignableFrom(p) && p != type);
        }

        public static IEnumerable<SelectListItem> MakeSelectList<T>(this IEnumerable<T> list, string dataValueField, string dataTextField, string defaultValue = null)
        {
            var selectList = new List<SelectListItem>(new SelectList(list, dataValueField, dataTextField));

            if (!String.IsNullOrEmpty(defaultValue))
            {
                selectList.Insert(0, new SelectListItem { Text = defaultValue, Value = "" });
            }

            return selectList;
        }

        
    }
}