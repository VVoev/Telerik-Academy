namespace _02.IEnumerableExt
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class IEnumerableExtension
    {
        public static T MIN<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.First() == null)
            {
                throw new Exception("There are no elements in current collection.");
            }
            else
            {
                T minValue = elements.First();
                foreach (var element in elements)
                {
                    if (element.CompareTo(minValue) < 0)
                    {
                        minValue = element;
                    }
                }
                return minValue;
            }
        }
        public static T MAX<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.First() == null)
            {
                throw new Exception("There are no elements in current collection.");
            }
            else
            {
                T maxValue = elements.First();
                foreach (var element in elements)
                {
                    if (element.CompareTo(maxValue) > 0)
                    {
                        maxValue = element;
                    }
                }
                return maxValue;
            }
        }
        public static T Product<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.First() == null)
            {
                throw new Exception("There are no elements in current collection.");
            }
            else
            {
                T productValue = (dynamic)1;
                foreach (var element in elements)
                {
                    productValue = (dynamic)productValue * element;
                }
                return productValue;
            }
        }
        public static T SUM<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.First() == null)
            {
                throw new Exception("There are no elements in current collection.");
            }
            else
            {
                T sumValue = default(T);
                foreach (var element in elements)
                {
                    sumValue = (dynamic)sumValue + element;
                }
                return sumValue;
            }
        }
        public static double AVERAGE<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            if (elements.First() == null)
            {
                throw new Exception("There are no elements in current collection.");
            }
            else
            {
                T value = default(T);
                int index = 0;
                foreach (var element in elements)
                {
                    value = (dynamic)value + element;
                    index++;
                }
                return (dynamic)value / (double)index;
            }
        }
    }
}
