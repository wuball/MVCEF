using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Light.Framework.Web.Base.Extensions
{
    public static class EnumerableExtensions
    {
        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value)
        {
            return source.ToSelectList(text, value, null, null);
        }

        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, string optionalText)
        {
            return source.ToSelectList(text, value, null, optionalText);
        }

        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, Func<T, bool> selected)
        {
            return source.ToSelectList(text, value, selected, null);
        }

        public static List<SelectListItem> ToSelectList<T>(this IEnumerable<T> source, Func<T, object> text, Func<T, object> value, Func<T, bool> selected, string optionalText)
        {
            var items = new List<SelectListItem>();
            if (optionalText != null)
            {
                items.Add(new SelectListItem() { Text = optionalText, Value = string.Empty });
            }
            if (source == null)
            {
                return items;
            }
            foreach (var entity in source)
            {
                var item = new SelectListItem();
                item.Text = text(entity).ToString();
                item.Value = value(entity).ToString();
                if (selected != null)
                {
                    item.Selected = selected(entity);
                }
                items.Add(item);
            }
            return items;
        }
        

        public static void SelectByValue(this List<SelectListItem> list, string value)
        {
            foreach (var item in list)
            {
                item.Selected = item.Value == value;
            }
        }

        public static void Add(this List<SelectListItem> list, object text, object value, bool selected)
        {
            list.Add(new SelectListItem()
            {
                Text = text.ToString(),
                Value = value.ToString(),
                Selected = selected
            });
        }
    }
}
