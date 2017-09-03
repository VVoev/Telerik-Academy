using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.FindMajorant
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = new List<int>() { 2, 2, 3, 3, 2, 3, 4, 3, 3 };
            var majorant = FindMajorant(numbers);

            if (majorant == null)
            {
                Console.WriteLine("No majorant found!");
            }
            else
            {
                Console.WriteLine(majorant);
            }
        }

        private static int? FindMajorant(List<int> numbers)
        {
            int? majorant = null;
            numbers.ForEach(x =>
            {
                if (numbers.Count(n => n == x) >= numbers.Count / 2 + 1)
                {
                    majorant = x;
                    return;
                }
            });

            return majorant;
        }
    }
}
