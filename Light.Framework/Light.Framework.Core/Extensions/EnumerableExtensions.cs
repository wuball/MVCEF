using System;
using System.Collections.Generic;
using System.Linq;

namespace Light.Framework.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static string JoinString(this IEnumerable<string> values)
        {
            return JoinString(values, ",");
        }

        public static string JoinString(this IEnumerable<string> values, string split)
        {
            var result = values.Aggregate(string.Empty, (current, value) => current + (split + value));
            result = result.TrimStart(split.ToCharArray());
            return result;
        }

        public static IEnumerable<T> Each<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source != null)
            {
                foreach (var item in source)
                {
                    action(item);
                }
            }
            return source;
        }

        public static List<T> Distinct<T, TKey>(this IEnumerable<T> source, Func<T, TKey> key) where TKey : class
        {
            if (source == null)
            {
                return null;
            }
            var results = new List<T>();
            foreach (var item in source)
            {
                if (results.All(resultItem => key(resultItem) != key(item)))
                {
                    results.Add(item);
                }
            }
            return results;
        }

        /// <summary>
        /// 判断序列是否包含任何元素，如果序列为空，则返回False
        /// </summary>
        /// <typeparam name="T">序列类型</typeparam>
        /// <param name="source">序列</param>
        /// <returns></returns>
        public static bool AnyOne<T>(this IEnumerable<T> source)
        {
            return source != null ? source.Any() : false;
        }

    }
}
