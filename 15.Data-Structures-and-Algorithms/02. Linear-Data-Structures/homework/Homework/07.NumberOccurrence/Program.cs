using System.Collections.Generic;

namespace _07.NumberOccurrence
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var occurences = new SortedDictionary<int, int>();

            foreach (var item in list)
            {
                if (occurences.ContainsKey(item))
                {
                    occurences[item]++;
                }
                else
                {
                    occurences.Add(item, 1);
                }
            }


            foreach (var occurence in occurences)
            {
                Console.WriteLine("{0} -> {1} times", occurence.Key, occurence.Value);
            }

        }
    }
}
