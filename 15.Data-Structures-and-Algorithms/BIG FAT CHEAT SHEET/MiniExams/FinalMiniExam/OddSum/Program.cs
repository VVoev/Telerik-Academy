using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddSum
{
    public class Program
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToArray();

            long sum = 0;
            long minOdd = long.MaxValue;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > 0)
                {
                    sum += numbers[i];
                }

                if ((numbers[i] & 1) == 1)
                {
                    minOdd = Math.Min(minOdd, Math.Abs(numbers[i]));
                }
            }

            if ((sum & 1) == 0)
            {
                sum -= Math.Abs(minOdd);
            }

            Console.WriteLine(sum);
        }
    }
}
