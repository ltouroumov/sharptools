using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpTools.Utils.Collections
{
    public static class CollectionUtils
    {
        /// <summary>
        /// Provides a chainable 'ForEach' that returns itself
        /// </summary>
        /// <typeparam name="T">Enumerable type</typeparam>
        /// <param name="block">yield block</param>
        /// <returns>The enumerable itself</returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> self, Action<T> block)
        {
            foreach (var item in self) block(item);
            return self;
        }
    }

    /// <summary>
    /// Provides empty collection boxed as their interfaces
    /// </summary>
    public static class Collections
    {
        /// <summary>
        /// Provides an empty generic list boxed as IList
        /// </summary>
        public static IList<T> IList<T>()
        {
            return new List<T>();
        }

        /// <summary>
        /// Provides an empty generic dictionary boxed as IDictionary
        /// </summary>
        public static IDictionary<K, V> IDictionary<K, V>()
        {
            return new Dictionary<K, V>();
        }

        /// <summary>
        /// Provides an empty list boxed as IEnumerable
        /// </summary>
        public static IEnumerable<T> IEnumerable<T>()
        {
            return IList<T>();
        }

        /// <summary>
        /// Provides an empty list boxed as ICollection
        /// </summary>
        public static ICollection<T> ICollection<T>()
        {
            return IList<T>();
        }
    }
}
