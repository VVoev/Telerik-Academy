using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Fibonacci_Slow
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fibonachi from 10:");
            Console.WriteLine(Fibonachi(10));

            Console.WriteLine("Fibonachi from 40:");
            Console.WriteLine(Fibonachi(40));


            //very slow
            //Console.WriteLine("Fibonachi from 50:");
            //Console.WriteLine(Fibonachi(50));
        }

        private static decimal Fibonachi(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            else
            {
                return Fibonachi(n - 1) + Fibonachi(n - 2);
            }
        }
    }
}
