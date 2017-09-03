using System;
using System.Collections.Generic;

namespace _01.CountNumberOccurences
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };

            var dictionary = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (dictionary.ContainsKey(number))
                {
                    dictionary[number]++;
                }
                else
                {
                    dictionary[number] = 1;
                }
            }

            foreach (var kv in dictionary)
            {
                Console.WriteLine($"{kv.Key} => {kv.Value} times.");
            }
        }
    }
}
