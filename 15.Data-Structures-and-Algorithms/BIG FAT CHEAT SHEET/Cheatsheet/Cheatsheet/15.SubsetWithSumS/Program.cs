using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Election
{
    public class Program
    {
        public static void Main()
        {
            int targetSeats = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int[] numbers = new int[n];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = int.Parse(Console.ReadLine());
            }

            var result = Solve(numbers, targetSeats);
            Console.WriteLine(result);
        }

        public static BigInteger Solve(int[] numbers, int k)
        {
            var sum = numbers.Sum();

            var subsetSums = new BigInteger[sum + 1];
            subsetSums[0] = 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = sum; j >= 0; j--)
                {
                    if (subsetSums[j] > 0)
                    {
                        subsetSums[j + numbers[i]] += subsetSums[j];
                    }
                }
            }

            BigInteger result = 0;
            for (int i = k; i < subsetSums.Length; i++)
            {
                result += subsetSums[i];
            }

            // Console.WriteLine(string.Join(" ", subsetSums));

            return result;
        }

        public static void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
