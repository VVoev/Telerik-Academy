using System;
using System.Collections.Generic;

namespace GraphsAlgorithms.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action action)
        {
            foreach (var item in enumerable)
            {
                action();
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T, int> action)
        {
            var index = 0;
            foreach (var item in enumerable)
            {
                action(item, index);
                ++index;
            }
        }

        public static void Print<T>(this IEnumerable<T> enumerable)
        {
            Console.WriteLine(string.Join(", ", enumerable));
        }
    }
}
