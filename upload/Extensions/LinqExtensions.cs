using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace upload.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<(T Value, int Index)> WithIndex<T>(this IEnumerable<T> source)
            => source.Select((item, index) => (item, index));

        public static void ForEach<T>(this IEnumerable<T> thisValue, Action<T> action)
        {
            foreach (var value in thisValue)
                action?.Invoke(value);
        }
    }
}