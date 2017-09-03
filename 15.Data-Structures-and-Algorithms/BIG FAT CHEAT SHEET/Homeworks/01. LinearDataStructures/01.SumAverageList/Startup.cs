using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAverageList
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = ReadNumbers();
            int sum = numbers.Sum();
            double average = numbers.Average();
            Console.WriteLine($"Sum = {sum}, Average = {average}");
        }

        private static IList<int> ReadNumbers()
        {
            var numbers = new List<int>();

            string line = Console.ReadLine();
            while(line != string.Empty)
            {

                numbers.Add(int.Parse(line));

                line = Console.ReadLine();
            }

            return numbers;
        }
    }
}
