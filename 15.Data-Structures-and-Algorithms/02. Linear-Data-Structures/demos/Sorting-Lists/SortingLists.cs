namespace Sorting_Lists
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class SortingLists
    {
        public static void Main()
        {
            var list = new List<DateTime>
                           {
                               new DateTime(2013, 4, 7),
                               new DateTime(2002, 3, 12),
                               new DateTime(2012, 1, 4),
                               new DateTime(1980, 11, 11),
                           };

            list.Sort();
            Console.WriteLine("Sorted by year with .Sort():");
            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine();
            list.Sort((d1, d2) => -d1.Day.CompareTo(d2.Day));
            Console.WriteLine("Sorted by year desc with .Sort(Comparison<T>):");
            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine();
            Console.WriteLine("Sorted by month with OrderBy(keySelector):");
            Console.WriteLine(string.Join(", ", list.OrderBy(date => date.Month)));
        }
    }
}
