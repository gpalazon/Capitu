using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Capitu.Infra
{
    public static class ListExtensions
    {
        public static SelectList ToSelectList<T>(this IEnumerable<T> enumerable,
                                                 Func<T, string> text,
                                                 Func<T, string> value,
                                                 string defaultOption = null,
                                                 string selectedValue = null)
        {
            var items = enumerable.Select(f => new SelectListItem
            {
                Text = text(f),
                Value = value(f),
            }).ToList();

            if (!string.IsNullOrEmpty(defaultOption))
                items.Insert(0, new SelectListItem
                {
                    Text = defaultOption,
                    Value = String.Empty
                });


            if (!string.IsNullOrEmpty(selectedValue))
                return new SelectList(items, "Value", "Text", selectedValue);

            return new SelectList(items, "Value", "Text");
        }

        public static IEnumerable<TOutput> ConvertAll<T, TOutput>(this IEnumerable<T> enumerable, Converter<T, TOutput> converter)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (converter == null)
            {
                throw new ArgumentNullException("converter");
            }

            int size = enumerable.Count();

            List<TOutput> list = new List<TOutput>(size);

            for (int i = 0; i < size; i++)
            {
                list.Add(converter(enumerable.ElementAt(i)));
            }

            return list;
        }

        public static bool HasDuplicates<T, TKey>(this IEnumerable<T> enumerable, Func<T, TKey> keySelector)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (keySelector == null)
            {
                throw new ArgumentNullException("keySelector");
            }

            return enumerable.GroupBy(keySelector).Where(i => i.Count() > 1).Count() > 0;
        }

        public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (selector == null)
            {
                throw new ArgumentNullException("selector");
            }

            return source.Aggregate(TimeSpan.Zero, (current, item) => current + selector(item));
        }
    }
}
