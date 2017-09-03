using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GraphsAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');
            int nodesCount = int.Parse(line[0]);
            var edgesCount = int.Parse(line[1]);

            var graph = ReadGraph();
            TopologicalSort();
        }

        static LinkedList<int>[] ReadGraph()
        {
            var line = Console.ReadLine().Split(' ');
            int n = int.Parse(line[0]);
            int m = int.Parse(line[1]);

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

        class TopoNode
        {
            public LinkedList<int> Children { get; set; }
            public int ParentsCount { get; set; }
        }
    }
}
