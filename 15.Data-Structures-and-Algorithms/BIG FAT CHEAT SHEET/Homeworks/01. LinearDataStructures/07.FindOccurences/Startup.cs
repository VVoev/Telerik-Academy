using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.FindOccurences
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 3, 4, 4, 2, 3, 3, 4, 3, 2 };
            ShowOccurences(numbers);
        }

        private static void ShowOccurences(IList<int> numbers)
        {
            numbers
                .GroupBy(x => x)
                .ToList()
                .ForEach(n =>
                {
                    Console.WriteLine($"{n.Key} -> {numbers.Count(x => x == n.Key)} times");
                });
        }
    }
}