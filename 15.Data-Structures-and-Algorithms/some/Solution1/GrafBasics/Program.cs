using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafBasics
{
    class Program
    {
        static string input = @"7
8
1 4
1 7
2 6
2 7
3 5
3 6
3 7
5 6";


        static void Main(string[] args)
        {
            FakeInput();
            //PrintGrapfWithMatrix();
            PrintGrafWithAdjustencyList();
        }

        private static void PrintGrafWithAdjustencyList()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n+1];
            for (int i = 0; i < n; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];

                vertices[from].AddLast(to);

            }
        }

        private static void PrintGrapfWithMatrix()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[n + 1, m + 1];
            for (int i = 0; i < n; i++)
            {
                var edge = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = edge[0];
                var to = edge[1];
                matrix[from, to] = true;
                matrix[to, from] = true;
            }

            Print(matrix);
        }

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }
        private static void Print(bool[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] ? 1 : 0);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
