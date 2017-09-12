using System;
using System.Linq;

namespace HyperRook
{
    class Program
    {
        static void Main()
        {
            var strs = Console.ReadLine().Split(' ');
            var n = int.Parse(strs[0]);
            var m = int.Parse(strs[1]);
            var d = int.Parse(strs[2]);
            var p = int.Parse(strs[3]);
            var q = int.Parse(strs[4]);

            var points = new int[q][];
            for (int i = 0; i < q; ++i)
            {
                points[i] = Console.ReadLine()
                                    .Split(' ')
                                    .Select(int.Parse)
                                    .ToArray();
            }

            if (p == 1)
            {
                var resultZeros = new int[q];
                var line = string.Join(" ", resultZeros);
                for (int i = 0; i < q; ++i)
                {
                    Console.WriteLine(line);
                }
                return;
            }

            var rookMatrix = new Matrix(n + 1, p);

            for (int k = 1; k <= n; ++k)
            {
                rookMatrix.Table[k, k] = k * (m - 2);
                rookMatrix.Table[k - 1, k] = (n + 1 - k) * (m - 1);
                rookMatrix.Table[k, k - 1] = k;
            }

            var resultMatrix = rookMatrix.FastPower(d);

            //for (int i = 0; i < 3; ++i)
            //{
            //    for (int j = 0; j < 3; ++j)
            //    {
            //        Console.Write(" " + resultMatrix.Table[i, j]);
            //    }
            //    Console.WriteLine();
            //}


            var resultLine = new int[q];

            for (int i = 0; i < q; ++i)
            {
                for (int j = 0; j < q; ++j)
                {
                    var different = GetDifferent(points[i], points[j]);
                    resultLine[j] = resultMatrix.Table[different, 0];
                }
                Console.WriteLine(string.Join(" ", resultLine));
            }
        }

        static int GetDifferent(int[] p1, int[] p2)
        {
            var result = 0;
            for (int i = 0; i < p1.Length; i++)
            {
                if (p1[i] != p2[i])
                {
                    ++result;
                }
            }

            return result;
        }
    }
}
