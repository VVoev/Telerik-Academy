using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Edge
    {
        public Edge(int from, int to)
        {
            From = from;
            To = to;
        }

        public int From { get; set; }

        public int To { get; set; }

        public int Distance { get; set; }

        public override string ToString()
        {
            return $"{this.From} -> {this.To}";
        }
    }

    class Program
    {
        private static string input = @"7
8
2 6 4
1 4 5
1 7 6
2 7 7
3 6 8
3 5 9
5 6 10
3 7 1";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();

            //PrintGraphWithMatrix();
            //PrintGraphWithAdjecencyList();
            PrintGraphWithSetOfEdges();
        }

        private static void PrintGraphWithSetOfEdges()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var edges = new List<Edge>();

            for (var i = 0; i < m; i++)
            {
                var edgeParts = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var edge1 = new Edge(edgeParts[0], edgeParts[1]);
                edges.Add(edge1);

                var edge2 = new Edge(edgeParts[1], edgeParts[0]);
                edges.Add(edge2);
            }

            edges = edges.OrderBy(e => e.From)
                .ThenBy(e => e.To)
                .ToList();

            edges.ForEach(edge => Console.WriteLine(edge));
        }

        class Node
        {
            public Node(int to, int distance)
            {
                To = to;
                Distance = distance;
            }

            public int To { get; set; }

            public int Distance { get; set; }
        }


        private static void PrintGraphWithAdjecencyList()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices =
                new LinkedList<Node>[n + 1];

            var vertices2 =
                new LinkedList<int[]>[n + 1];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var from = edge[0];
                var to = edge[1];
                if (vertices[from] == null)
                {
                    vertices[from] = new LinkedList<Node>();
                }
                if (vertices[to] == null)
                {
                    vertices[to] = new LinkedList<Node>();
                }
                vertices[from].AddLast(new Node(to, edge[2]));
                vertices[to].AddLast(new Node(from, edge[2]));
            }
            for (var i = 1; i < vertices.Length; i++)
            {
                var edges = vertices[i];
                Console.WriteLine(i + ": " + string.Join(", ", edges));
            }
        }

        private static void PrintGraphWithMatrix()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var matrix = new int[n + 1, n + 1];
            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var from = edge[0];
                var to = edge[1];
                matrix[from, to] = edge[2];
                // undirected graph
                matrix[to, from] = edge[2];
            }

            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
