using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.BinaryTree
{
    public class Program
    {
        static HashSet<ulong> passedNumbers = new HashSet<ulong>();
        static int[] results = new int[4];
        static ulong max;
        static ulong p;
        static ulong[] numbers;

        public static void Main()
        {
            p = ulong.Parse(Console.ReadLine());
            numbers = Console.ReadLine().Split(' ').Select(ulong.Parse).ToArray();
            max = numbers.Max();

            DFS(1);

            Console.WriteLine(string.Join(" ", results.Select(x => x == 1 ? 1 : 0)));
        }

        public static void DFS(ulong currentNumber)
        {
            if (currentNumber > max)
            {
                return;
            }

            for (int i = 0; i < 4; i++)
            {
                var targetNumber = numbers[i] - currentNumber;
                if (passedNumbers.Contains(targetNumber))
                {
                    results[i]++;
                }
            }

            passedNumbers.Add(currentNumber);

            DFS(currentNumber * p);
            DFS(currentNumber * p + 1);
        }
    }
}