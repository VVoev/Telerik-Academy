using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Businesman
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger result = Factorial(n) / (Factorial(n/ 2) * Factorial(n/2 + 1));
            Console.WriteLine(result);
        }

        public static BigInteger Factorial(int n)
        {
            BigInteger result = 1;
            while(n > 0)
            {
                result *= n;
                n--;
            }

            return result;
        }
    }
}
