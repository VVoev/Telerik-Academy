using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renewal
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var adjMatrix = ReadAdjacencyMatrix(n);
            var buildMatrix = ReadMatrix(n);
            var destroyMatrix = ReadMatrix(n);

            int result = 0;
            var edges = new List<Edge>(0);

            for (int row = 0; row < n; row++)
            {
                for (int col = row + 1; col < n; col++)
                {
                    if (adjMatrix[row, col])
                    {
                        result += destroyMatrix[row, col];
                        edges.Add(new Edge(row, col, -destroyMatrix[row, col]));
                    }
                    else
                    {
                        edges.Add(new Edge(row, col, buildMatrix[row, col]));
                    }
                }
            }

            edges.Sort((a, b) => a.Weight - b.Weight);
            // Console.WriteLine(string.Join("\n", edges.Select(x => x.Weight)));
            // Console.WriteLine(edges.Count);

            var unionFind = Enumerable.Range(0, n)
                    .Select(x => -1)
                    .ToArray();

            foreach (var edge in edges)
            {
                if (Union(unionFind, edge.From, edge.To))
                {
                    result += edge.Weight;
                }
            }

            Console.WriteLine(result);
        }

        public static int Find(int[] arr, int index)
        {
            if (arr[index] == -1)
            {
                return index;
            }

            arr[index] = Find(arr, arr[index]);
            return arr[index];
        }

        public static bool Union(int[] arr, int first, int second)
        {
            first = Find(arr, first);
            second = Find(arr, second);

            if (first == second)
            {
                return false;
            }

            arr[first] = second;
            return true;
        }

        public static bool[,] ReadAdjacencyMatrix(int n)
        {
            var matrix = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = line[j] == '1';
                }
            }

            return matrix;
        }

        public static int[,] ReadMatrix(int n)
        {
            var matrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = GetLetterValue(line[j]);
                }
            }

            return matrix;
        }

        public static int GetLetterValue(char letter)
        {
            if (char.IsUpper(letter))
            {
                return letter - 'A';
            }

            return letter - 'a' + 26;
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

        private class Edge
        {
            public Edge(int from, int to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }

            public int From { get; set; }

            public int To { get; set; }

            public int Weight { get; set; }
        }
    }
}
