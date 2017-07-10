using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    static class LinearSearch
    {
        public static int FindFirst<T>(this IEnumerable<T> array, T value)
            where T : IComparable<T>
        {
            int index = 0;
            foreach(var x in array)
            {
                if (x.CompareTo(value) == 0)
                {
                    return index;
                }
                ++index;
            }

            return -1;
        }

        public static int FindFirst<T>(this IEnumerable<T> array, Func<T, bool> f)
        {
            int index = 0;
            foreach(var x in array)
            {
                if (f(x))
                {
                    return index;
                }
                ++index;
            }

            return -1;
        }
    }
}
