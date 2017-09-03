using System;
using System.Linq;
using System.Numerics;

namespace RingsOfTheAcademy
{
    public class Program
    {
        static BigInteger[] memo;

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var rings = new int[n + 1];
            for (int i = 0; i < n; i++)
            {
                int hangsOn = int.Parse(Console.ReadLine());
                rings[hangsOn]++;
            }

            memo = new BigInteger[rings.Max() + 1];
            memo[0] = 1;

            BigInteger result = 1;
            for (int i = 1;i < rings.Length; i++)
            {
                result *= Factorial(rings[i]);
            }

            Console.WriteLine(result);
        }

        public static BigInteger Factorial(int number)
        {
            if (memo[number] != 0)
            {
                return memo[number];
            }

            BigInteger result = 1;
            int num = number;
            while (num > 0)
            {
                result *= num;
                num--;
            }

            memo[number] = result;
            return result;
        }
    }
}