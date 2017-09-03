using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphsAndGraphAlgorithms
{
    public class Startup
    {
        public static void Main()
        {
            var printer = new Printer();
            int nodesCount = int.Parse(Console.ReadLine());

            var graph = ReadAdjacencyListsGraph(nodesCount);

            while (true)
            {
                //BFS(graph, int.Parse(Console.ReadLine()));
                //DFSIterative(graph, int.Parse(Console.ReadLine()));
                DFSRecursive(graph, int.Parse(Console.ReadLine()), new bool[graph.Length]);
                Console.WriteLine();
            }

            // var graph = ReadAdjacencyMatrixGraph(nodesCount);

            // var graph = ReadSetOfEdgesGraph();
        }

        public static void DFSRecursive(LinkedList<int>[] graph, int currentNode, bool[] visited)
        {
            if (visited[currentNode])
            {
                return;
            }

            visited[currentNode] = true;

            // do stuff with vertex
            Console.WriteLine(currentNode);

            foreach (var node in graph[currentNode])
            {
                DFSRecursive(graph, node, visited);
            }
        }

        public static void DFSIterative(LinkedList<int>[] graph, int startNode)
        {
            var visited = new bool[graph.Length];
            visited[startNode] = true;
            var stack = new Stack<int>();

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                Console.WriteLine(currentNode);
                foreach (var successor in graph[currentNode])
                {
                    if (!visited[successor])
                    {
                        stack.Push(successor);
                        visited[successor] = true;
                    }
                }
            }
        }

        public static void BFS(LinkedList<int>[] nodes, int startNode)
        {
            var visited = new bool[nodes.Length];
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited[startNode] = true;

            int currentNode;
            while (queue.Count > 0)
            {
                currentNode = queue.Dequeue();
                Console.WriteLine(currentNode);
                foreach (var successor in nodes[currentNode])
                {
                    if (!visited[successor])
                    {
                        queue.Enqueue(successor);
                        visited[successor] = true;
                    }
                }
            }
        }

        public static LinkedList<int>[] ReadAdjacencyListsGraph(int nodesCount)
        {
            var graph = new LinkedList<int>[nodesCount + 1];

            while (true)
            {
                string line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var edge = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int from = edge[0];
                int to = edge[1];

                if (graph[from] == null)
                {
                    graph[from] = new LinkedList<int>();
                }

                graph[from].AddLast(to);
            }

            return graph;
        }

        public static int[,] ReadAdjacencyMatrixGraph(int nodesCount)
        {
            var graph = new int[nodesCount + 1, nodesCount + 1];

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var connectionParts = line
                        .Split(' ')
                        .Select(int.Parse)
                        .ToArray();

                int from = connectionParts[0];
                int to = connectionParts[1];

                graph[from, to] = 1;
            }

            return graph;
        }


        public static List<Edge<int>> ReadSetOfEdgesGraph()
        {
            var edgesList = new List<Edge<int>>();

            string line;
            while (true)
            {
                line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var edgeParts = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var from = edgeParts[0];
                var to = edgeParts[1];

                var edge = new Edge<int>(from, to);
                edgesList.Add(edge);
            }

            return edgesList;
        }
    }
}
