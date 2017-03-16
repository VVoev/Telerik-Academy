namespace StatisticProblem.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class StatisticExtensions
    {
        public static void PrintStatistics<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            Console.WriteLine(string.Format("Check Statistic Below"));
            Console.WriteLine(string.Format("Max: {0}", arrayOfElements.CalculateMax()));
            Console.WriteLine(string.Format("Min: {0}", arrayOfElements.CalculateMin()));
            Console.WriteLine(string.Format("Average: {0}", arrayOfElements.CalculateAverage()));
        }

        public static T CalculateMax<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            return arrayOfElements.Max();
        }

        private static T CalculateMin<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            return arrayOfElements.Min();
        }

        private static T CalculateAverage<T>(this IEnumerable<T> arrayOfElements) where T : IComparable<T>
        {
            dynamic sum = arrayOfElements.Aggregate<T, dynamic>(0, (current, ellement) => current + ellement);
            return (T)(sum / arrayOfElements.Count());
        }
    }
}
