using System;
using System.Numerics;

namespace Fibonacci
{
    class Program
    {
        const long Mod = 1000000007;

        static void Main()
        {
            var n = 1000000000000000000;
            var fiboMatrix = new Matrix22(
                1, 1,
                1, 0);

            Console.WriteLine(FastPower(fiboMatrix, n, Mod).UpperLeftCorner);
        }

        static Matrix22 FastPower(Matrix22 matrix, long p, long mod)
        {
            if (p == 0)
            {
                return new Matrix22(1, 0, 0, 1);
            }

            if (p % 2 == 1)
            {
                return matrix.MultiplyTo(FastPower(matrix, p - 1, mod)).ModDivide(mod);
            }

            return FastPower(matrix, p / 2, mod).Square().ModDivide(mod);
        }
    }
}
