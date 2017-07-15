using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong muliplier;
            ulong[] numbers;
            List<int> results;
            inputs(out muliplier, out numbers, out results);
            convertToCSharp(muliplier, numbers, results);
        }

        private static void convertToCSharp(ulong muliplier, ulong[] numbers, List<int> results)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                results.Add(CheckIfPretty(muliplier, numbers[i]));
            }

            Console.WriteLine(string.Join(" ", results));
        }

        private static void inputs(out ulong muliplier, out ulong[] numbers, out List<int> results)
        {
            muliplier = ulong.Parse(Console.ReadLine());
            numbers = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();
            results = new List<int>();
        }

        private static int CheckIfPretty(ulong p, ulong n)
        {
            int[] a = new int[] { 0, 0, 0, 0 };
            ulong r = 0;

            while (n != 0)
            {
                r = n % p;
                n /= p;
                if (r < 3)
                {
                    a[r]++;
                }
                else
                {
                    a[3]++;
                }
            }
            if (a[3] > 0)
            {
                return 0;
            }

            if (a[1] == 1 && a[2] > 0)
            {
                return 1;
            }

            if (a[1] == 2 && a[2] == 0)
            {
                return 1;
            }

            return 0;
        }
    }
}