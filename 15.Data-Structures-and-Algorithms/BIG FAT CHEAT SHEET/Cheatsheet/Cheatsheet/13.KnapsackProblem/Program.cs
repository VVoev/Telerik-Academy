using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace KnapsackAlgo
{
    class KnapsackAlgorithm
    {
        static Node[] nodes;

        static void Main(string[] args)
        {
            //int[] value = { 10, 50, 70 };
            //int[] weight = { 10, 20, 30 };
            //int capacity = 40;
            //int itemsCount = 3;

            //int result = KnapSack(capacity, weight, value, itemsCount);
            //Console.WriteLine(result);
            int maxWeight = int.Parse(Console.ReadLine());
            int foodsCount = int.Parse(Console.ReadLine());

            nodes = new Node[foodsCount + 1];
            var weights = new int[foodsCount];
            var values = new int[foodsCount];

            for (int i = 1; i < foodsCount + 1; i++)
            {
                var line = Console.ReadLine().Split(' ');
                weights[i - 1] = int.Parse(line[1]);
                values[i - 1] = int.Parse(line[2]);
                nodes[i] = new Node(line[0], int.Parse(line[1]), int.Parse(line[2]));
            }

            var result = KnapSackCopied(maxWeight, weights, values, foodsCount);
            Console.WriteLine(result.Item1);
            Console.WriteLine(string.Join("\n", result.Item2));
        }

        public static Tuple<int, List<string>> KnapSackCopied(int capacity, int[] weight, int[] value, int itemsCount)
        {
            int[,] K = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (weight[i - 1] <= w)
                        K[i, w] = Math.Max(value[i - 1] + K[i - 1, w - weight[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            var results = new List<string>();
            int col = capacity;

            for (int row = itemsCount; row > 0; row--)
            {
                if (K[row - 1, col] == K[row, col])
                {
                    continue;
                }
                else
                {
                    results.Add(nodes[row].Name);
                    col = Math.Abs(col - nodes[row].Weight);
                }
            }

            return new Tuple<int, List<string>>(K[itemsCount, capacity], results);
        }

        public static void PrintMatrix(int[,] matrix)
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

    public class Node
    {
        public Node(string name, int weight, int value)
        {
            this.Name = name;
            this.Weight = weight;
            this.Value = value;
        }

        public int Weight { get; set; }

        public int Value { get; set; }

        public string Name { get; set; }
    }
}