using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.SumToZero
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Please enter a number");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine($"The summ of all numbers till zero is {SumTillZero(n)}");

        }

        private static int SumTillZero(int n)
        {
            if (n == 1)
            {
                return n;
            }
            else
            {
                return n+SumTillZero(n - 1);
            }
        }
    }
}
