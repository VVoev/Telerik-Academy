using System;
using System.Collections.Generic;

namespace DijkstraAlgorithm
{
    public class Startup
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var graph = ReadGraph(nodesCount);

            while (true)
            {
                string sourceTown = Console.ReadLine();
                var shortestPaths = GetShortestPathsFrom(sourceTown, graph);
                Console.WriteLine(string.Join("\n", shortestPaths));
                Console.WriteLine();
            }
        }

        public static List<string> GetShortestPathsFrom(string startNode, Dictionary<string, LinkedList<EdgeNode>> graph)
        {
            var visited = new Dictionary<string, bool>();
            var distances = new Dictionary<string, int>();
            foreach (var kv in graph)
            {
                distances.Add(kv.Key, int.MaxValue);
                visited.Add(kv.Key, false);
            }

            var queue = new PriorityQueue<NodeDistance>((a, b) => a.Distance > b.Distance);

            distances[startNode] = 0;
            queue.Enqueue(GetNodeDistance(startNode, 0));
            
            while (!queue.IsEmpty)
            {
                var currentNodeDistance = queue.Dequeue();

                foreach (var successor in graph[currentNodeDistance.Node])
                {
                    if (visited[successor.Target])
                    {
                        continue;
                    }

                    var newDistance = distances[currentNodeDistance.Node] + successor.Weight;
                    if (distances[successor.Target] < newDistance)
                    {
                        continue;
                    }

                    distances[successor.Target] = newDistance;
                    queue.Enqueue(new NodeDistance(successor.Target, newDistance));
                }

                visited[currentNodeDistance.Node] = true;
            }

            var result = new List<string>();
            foreach (var kv in distances)
            {
                result.Add($"{kv.Key} => {kv.Value}");
            }

            return result;
        }

        public static NodeDistance GetNodeDistance(string node, int distance)
        {
            return new NodeDistance(node, distance);
        }
        
        public static Dictionary<string, LinkedList<EdgeNode>> ReadGraph(int size)
        {
            var graph = new Dictionary<string, LinkedList<EdgeNode>>(size + 1);

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line.ToLower() == "end")
                {
                    return graph;
                }

                var connectionParts = line.Split(' ');

                string from = connectionParts[0];
                string to = connectionParts[1];
                int weight = int.Parse(connectionParts[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new LinkedList<EdgeNode>());
                }

                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new LinkedList<EdgeNode>());
                }

                graph[from].AddLast(new EdgeNode(to, weight));
                graph[to].AddLast(new EdgeNode(from, weight));
            }
        }
    }
}
