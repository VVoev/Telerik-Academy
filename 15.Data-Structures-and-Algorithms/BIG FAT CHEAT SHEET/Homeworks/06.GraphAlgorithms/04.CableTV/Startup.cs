using System;
using System.Collections.Generic;
using System.Linq;

namespace MinimumSpanningTree
{
    public class Startup
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            var graph = ReadGraph(nodesCount, edgesCount);
            int startNode = 1;

            var tree = new HashSet<int>();
            tree.Add(startNode);
            var queue = new PriorityQueue<Edge>((a, b) => a.Weight > b.Weight);

            foreach (var node in graph[startNode])
            {
                queue.Enqueue(new Edge(startNode, node.Target, node.Weight));
            }

            while (!queue.IsEmpty)
            {
                var currentSmallestEdge = queue.Dequeue();

                int node = -1;
                while (!queue.IsEmpty)
                {
                    if (!tree.Contains(currentSmallestEdge.From))
                    {
                        node = currentSmallestEdge.From;
                        break;
                    }
                    else if (!tree.Contains(currentSmallestEdge.To))
                    {
                        node = currentSmallestEdge.To;
                        break;
                    } 
                    else
                    {
                        currentSmallestEdge = queue.Dequeue();
                    }
                }

                if (node == -1)
                {
                    break;
                }

                tree.Add(node);

                foreach (var successor in graph[node])
                {
                    queue.Enqueue(new Edge(node, successor.Target, successor.Weight));
                }
            }

            Console.WriteLine(string.Join(" -> ", tree));
        }

        public static PriorityQueue<Edge> GetQueueWithEdges(LinkedList<Node>[] graph)
        {
            var queue = new PriorityQueue<Edge>((a, b) => a.Weight > b.Weight);

            for (int i = 1; i < graph.Length; i++)
            {
                foreach (var connection in graph[i])
                {
                    queue.Enqueue(new Edge(i, connection.Target, connection.Weight));
                }
            }

            return queue;
        }

        public static LinkedList<Node>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new LinkedList<Node>[nodesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                var connection = Console.ReadLine()
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                var from = connection[0];
                var to = connection[1];
                var weight = connection[2];

                AddNode(graph, from, to, weight);
                AddNode(graph, to, from, weight);
            }

            return graph;
        }

        public static void AddNode(LinkedList<Node>[] graph, int from, int to, int weight)
        {
            if (graph[from] == null)
            {
                graph[from] = new LinkedList<Node>();
            }

            graph[from].AddLast(new Node(to, weight));
        }
    }
}
