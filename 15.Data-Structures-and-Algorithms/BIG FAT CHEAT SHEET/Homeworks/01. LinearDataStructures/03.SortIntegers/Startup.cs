using System;
using System.Collections.Generic;

namespace _03.SortIntegers
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>();
            string lineRead = Console.ReadLine();
            while (!string.IsNullOrEmpty(lineRead))
            {
                int number;
                int.TryParse(lineRead, out number);
                numbers.Add(number);
                lineRead = Console.ReadLine();
            }

            numbers.Sort();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
