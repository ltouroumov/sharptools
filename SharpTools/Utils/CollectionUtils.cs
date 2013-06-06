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
}
