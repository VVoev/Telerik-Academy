using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiskWinsRiskLoses
{
    public class Program
    {
        static string targetCode;

        public static void Main()
        {
            var initialCode = Console.ReadLine();
            targetCode = Console.ReadLine();

            var visited = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                visited.Add(Console.ReadLine());
            }

            var queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(new Tuple<string, int>(initialCode, 0));

            StringBuilder builder;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                for (int i = 0; i < 5; i++)
                {
                    var digit = current.Item1[i] - '0';
                    digit--;
                    if (digit < 0)
                    {
                        digit = 9;
                    }

                    builder = new StringBuilder(current.Item1);
                    builder[i] = (char)(digit + '0');

                    var newNode = builder.ToString();
                    if (newNode == targetCode)
                    {
                        Console.WriteLine(current.Item2 + 1);
                        return;
                    }

                    if (!visited.Contains(newNode))
                    {
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                        visited.Add(newNode);
                    }

                    digit = current.Item1[i] - '0';

                    digit++;
                    if (digit > 9)
                    {
                        digit = 0;
                    }

                    builder[i] = (char)(digit + '0');

                    newNode = builder.ToString();
                    if (newNode == targetCode)
                    {
                        Console.WriteLine(current.Item2 + 1);
                        return;
                    }

                    if (!visited.Contains(newNode))
                    {
                        queue.Enqueue(new Tuple<string, int>(newNode, current.Item2 + 1));
                        visited.Add(newNode);
                    }

                    builder[i] = current.Item1[i];
                }

               
            }

            Console.WriteLine(-1);
        }

        static int min = int.MaxValue;

        public static void Solve(int index, string currentCode, HashSet<string> forbidden, int steps)
        {
            if (index >= currentCode.Length)
            {
                if (currentCode == targetCode)
                {
                    if (steps < min)
                    {
                        min = steps;
                    }
                }

                return;
            }

            int currentDigit = currentCode[index] - '0';
            int targetDigit = currentCode[index] - '0';
        }
    }
}
