using System;
using System.Collections.Generic;
using System.Linq;

namespace _Graph_BaiIvan
{
    class Program
    {
        static void Main(string[] args)
        {
            var fuelPrice = double.Parse(Console.ReadLine());
            var fields = int.Parse(Console.ReadLine());
            var house = new Node(0, 0);

            var nodes = new List<Node>();
            nodes.Add(house);

            var visited = new bool[fields];
            visited[0] = true;

            for (int i = 0; i < fields; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var node = new Node(line[0], line[1]);
                nodes.Add(node);
            }


            BFS(nodes, visited, 0, 0);
        }

        private static void BFS(List<Node> nodes, bool[] visited, int pointX, int pointY)
        {

            for (int i = 0; i < nodes.Count-1; i++)
            {
                var node = nodes[i];
                var nextNode = nodes[i + 1];
                var distance = CalculateDistance(node, nextNode);
                Console.WriteLine(distance);
            }
        }

        private static double CalculateDistance(Node a,Node b)
        {
            var distance = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            return distance;
        }


    }

    class Node
    {
        public int X { get; set; }

        public int Y { get; set; }

        public Node(int x,int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
