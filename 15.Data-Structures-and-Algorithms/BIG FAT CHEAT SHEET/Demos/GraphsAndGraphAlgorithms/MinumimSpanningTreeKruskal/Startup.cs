using System;
using System.Collections.Generic;
using System.Linq;

namespace MinumimSpanningTreeKruskal
{
    public class Startup
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            var trees = new int[nodesCount + 1];
            trees = trees.Select(_ => -1).ToArray();

            var graph = ReadGraph(edgesCount);
            var queue = new PriorityQueue<Edge>((a, b) => a.Weight > b.Weight);

            graph.ForEach(ed => queue.Enqueue(ed));
            var result = new List<Edge>();
            while (!queue.IsEmpty)
            {
                var currentEdge = queue.Dequeue();

                var baseFrom = Find(trees, currentEdge.From);
                var baseTo = Find(trees, currentEdge.To);

                if (baseFrom == baseTo)
                {
                    continue;
                }

                trees[baseTo] = baseFrom;
                result.Add(currentEdge);
            }

            foreach (var edge in result)
            {
                Console.WriteLine($"{edge.From}:{edge.To} => {edge.Weight}");
            }
        }

        public static int Find(int[] trees, int index)
        {
            if (trees[index] == -1)
            {
                return index;
            }

            trees[index] = Find(trees, trees[index]);
            return trees[index];
        }

        public static List<Edge> ReadGraph(int edgesCount)
        {
            var graph = new List<Edge>();

            for (int i = 0; i < edgesCount; i++)
            {
                var connection = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var from = connection[0];
                var to = connection[1];
                var weight = connection[2];

                var firstEdge = new Edge(from, to, weight);
                var secondEdge = new Edge(to, from, weight);

                graph.Add(firstEdge);
                graph.Add(secondEdge);
            }

            return graph;
        }
    }
}
