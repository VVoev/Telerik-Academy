using System;
using System.Collections.Generic;

namespace Searching
{
    class Program
    {
        static void Main(string[] args)
        {
            // x^6 - 2 x^5 - 2.75 x^4 - 1.25 x^3 + x^2 + 1.75 x - 0.75
            var roots = PolynomialSolver.Solve(new List<double> { -0.75, 1.75, 1, -1.25, -2.75, -2, 1 });
            Console.WriteLine(string.Join(" ", roots));
        }

        static int[] GenShuffled(int n)
        {
            var array = new int[n];
            for (int i = 0; i < n; ++i)
            {
                array[i] = i;
            }

            var rnd = new Random();

            for (int i = n - 1; i > 0; --i)
            {
                var j = rnd.Next() % (i + 1);
                if (j != i)
                {
                    var k = array[j];
                    array[j] = array[i];
                    array[i] = k;
                }
            }

            return array;
        }
    }
}
