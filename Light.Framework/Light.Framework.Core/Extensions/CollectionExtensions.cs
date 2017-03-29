using System.Collections.Generic;
using System.Linq;

namespace Light.Framework.Core.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> source, IEnumerable<T> items)
        {
            if (items == null)
            {
                return;
            }
            foreach (var item in items)
            {
                source.Add(item);
            }
        }



        /// <summary>
        /// Collection to String by separator
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static string EnumerableToString<T>(this IEnumerable<T> collection, string separator = ",")
        {
            return collection.IsEmpty() ? null : string.Join(separator, collection);
        }

        /// <summary>
        /// Collection is null ?
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns>null=true</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            return !collection.Any();
        }
    }
}
