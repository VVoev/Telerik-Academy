using GraphsAlgorithms.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GraphsAlgorithms
{
    partial class Program
    {

        private static string input = @"9
13
1 9
2 5
2 8
3 1
3 6
4 3
4 6
5 1
7 1
7 4
7 8
8 1
8 5";
        //        private static string input = @"6
        //11
        //1 2 2
        //1 3 3
        //1 4 11
        //2 3 3
        //2 5 15
        //3 4 2
        //3 5 6
        //4 5 3
        //1 6 100
        //2 6 100
        //5 6 1";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static LinkedList<int>[] ReadGraph()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());

            var vertices = new LinkedList<int>[n];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = edge[0] - 1;
                var y = edge[1] - 1;

                AddEdge(vertices, x, y);
                AddEdge(vertices, y, x);
            }

            return vertices;
        }

        private static void AddEdge(LinkedList<int>[] vertices, int from, int to)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new LinkedList<int>();
            }

            vertices[from].AddLast(to);
        }

        static Dictionary<int, TopoNode> ReadDirectedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                var x = edge[0];
                var y = edge[1];

                if (vertices.ContainsKey(x) == false)
                {
                    vertices[x] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new LinkedList<int>(),
                    };
                }

                if (vertices.ContainsKey(y) == false)
                {
                    vertices[y] = new TopoNode
                    {
                        ParentsCount = 0,
                        Children = new LinkedList<int>(),
                    };
                }
                vertices[x].Children.AddLast(y);
                vertices[y].ParentsCount++;
            }

            return vertices;
        }

        static void Main()
        {
            FakeInput();

            //var result = TopologicalSort();
            //Console.WriteLine(string.Join(", ", result));

            //var vertices = ReadWeightedGraph();
            //var distances = Dijkstra(vertices, 1 - 1);
            //Console.WriteLine(string.Join(", ", distances));

            var vertices = ReadGraph();
            PrintPathWithDfsStack(vertices);
            PrintPathWithBfs(vertices);
        }

        private static List<int> TopologicalSort()
        {
            var graph = ReadDirectedGraph();
            var sources = ExtractSources(graph);

            var result = new List<int>();

            while (sources.Count > 0)
            {
                var source = sources.Dequeue();
                result.Add(source);
                var newSources = graph[source].Children;
                graph.Remove(source);
                UpdateSources(graph, newSources, sources);
            }

            return result;
        }

        private static void UpdateSources(Dictionary<int, TopoNode> graph, LinkedList<int> newSources, Queue<int> sources)
        {
            foreach (var newSource in newSources)
            {
                --graph[newSource].ParentsCount;
                if (graph[newSource].ParentsCount == 0)
                {
                    sources.Enqueue(newSource);
                }
            }
        }

        private static Queue<int> ExtractSources(Dictionary<int, TopoNode> graph)
        {
            var queue = new Queue<int>();
            foreach (var vertex in graph)
            {
                if (vertex.Value != null && vertex.Value.ParentsCount == 0)
                {
                    queue.Enqueue(vertex.Key);
                }
            }

            return queue;
        }

        private static int[] Dijkstra(List<Node>[] vertices, int start)
        {
            // regular for is better
            //var d = Enumerable.Range(1, vertices.Length)
            //    .Select(_ => int.MaxValue)
            //    .ToArray();
            const int INFINITY = int.MaxValue;

            var d = new int[vertices.Length];
            for (int i = 0; i < d.Length; i++)
            {
                d[i] = INFINITY;
            }

            d[start] = 0;

            var used = new HashSet<int>();
            var queue = new PriorityQueue<Node>();
            queue.Enqueue(new Node(start, 0));

            // repeat N times
            while (queue.IsEmpty == false)
            {
                //1. get best node to continue
                var node = queue.Dequeue();
                while (queue.IsEmpty == false &&
                    used.Contains(node.Vertex))
                {
                    node = queue.Dequeue();
                }

                used.Add(node.Vertex);

                // update distances for neightbours of best
                vertices[node.Vertex]
                    .ForEach(next =>
                    {
                        var currentDistance = d[next.Vertex];
                        var newDistance = d[node.Vertex] + next.Distance;

                        if (currentDistance <= newDistance) { return; }

                        d[next.Vertex] = newDistance;
                        queue.Enqueue(new Node(next.Vertex, newDistance));
                    });
            }
            return d;
        }

        private static List<Node>[] ReadWeightedGraph()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();

                AddWeightedEdge(vertices, edge[0] - 1, edge[1] - 1, edge[2]);
                AddWeightedEdge(vertices, edge[1] - 1, edge[0] - 1, edge[2]);
            }

            return vertices;
        }

        private static void AddWeightedEdge(List<Node>[] vertices, int from, int to, int distance)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }
            vertices[from].Add(new Node(to, distance));
        }

        private static void PrintPathWithDfsStack(LinkedList<int>[] vertices)
        {
            var startVertex = 3 - 1;
            var used = new bool[vertices.Length];
            used[startVertex] = true;
            var queue = new Stack<int>();
            var path = new int[vertices.Length];

            var distances = new int[vertices.Length];
            distances[startVertex] = 0;

            queue.Push(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Pop();
                Console.WriteLine(vertex + 1);
                foreach (var next in vertices[vertex])
                {
                    if (used[next])
                    {
                        continue;
                    }

                    used[next] = true;
                    path[next] = vertex;
                    distances[next] = distances[vertex] + 1;
                    queue.Push(next);
                }
            }

            distances
                .Select((index, value) => $"{index + 1}: {distances[index]}")
                .Print();

        }

        private static void PrintPathWithBfs(LinkedList<int>[] vertices)
        {
            var startVertex = 3 - 1;
            var used = new bool[vertices.Length];
            used[startVertex] = true;
            var queue = new Queue<int>();
            var path = new int[vertices.Length];

            var distances = new int[vertices.Length];
            distances[startVertex] = 0;

            queue.Enqueue(startVertex);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex + 1);
                foreach (var next in vertices[vertex])
                {
                    if (used[next])
                    {
                        continue;
                    }

                    used[next] = true;
                    path[next] = vertex;
                    distances[next] = distances[vertex] + 1;
                    queue.Enqueue(next);
                }
            }

            distances
                .Select((index, value) => $"{index + 1}: {distances[index]}")
                .Print();
        }

        private static void PrintPathWithDfs(LinkedList<int>[] vertices)
        {
            var vertex = 2 - 1;
            var used = new bool[vertices.Length];
            var path = new int[vertices.Length];
            path[vertex] = -1;
            Dfs(vertex, vertices, used, path, "");

            var current = 4 - 1;

            while (current != -1)
            {
                Console.WriteLine(current + 1);
                current = path[current];
            }
        }

        private static void Dfs(int vertex, LinkedList<int>[] vertices, bool[] used, int[] path, string prefix)
        {
            var nexts = vertices[vertex];

            Console.WriteLine(prefix + (vertex + 1));

            foreach (var next in nexts)
            {
                if (used[next])
                {
                    continue;
                }

                used[vertex] = true;
                path[next] = vertex;
                Dfs(next, vertices, used, path, prefix + "   ");
            }
        }
    }
}
