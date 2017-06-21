using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.LongestSequenceEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 3, 4, 1, 2, 2, 2, 3, 41, 10 };

            var result = LongestSequenceOfEqualElements(list);

            Console.WriteLine(string.Format("Max repeating sequence: {0}", string.Join(", ", result)));
        }

        private static List<int> LongestSequenceOfEqualElements(List<int> list)
        {
            int number = list[0];
            var count = 1;
            var max = 1;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (list[i] == list[i + 1])
                {
                    count++;
                }
                else
                {
                    count = 1;
                }

                if (count > max)
                {
                    max = count;
                    number = list[i];
                }
            }

            return Enumerable.Repeat(number, max).ToList();
        }
    }
}
