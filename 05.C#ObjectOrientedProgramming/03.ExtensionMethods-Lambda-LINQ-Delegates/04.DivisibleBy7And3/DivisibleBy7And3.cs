namespace _04.DivisibleBy7And3
{
    using System;
    using System.Linq;

    class DivisibleBy7And3
    {
        static void Main()
        {
            int n = 10;
            int[] integers = new int[n];
            var randomNumbers = new Random();
            for (int i = 0; i < n; i++)
            {
                integers[i] = randomNumbers.Next(1, 1000);
            }
            var result = integers.Where(x => x % 3 == 0 && x % 7 == 0)
                                 .ToList();
            // Note that numbers are random from 1 to 1000 and result may be empty.
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
