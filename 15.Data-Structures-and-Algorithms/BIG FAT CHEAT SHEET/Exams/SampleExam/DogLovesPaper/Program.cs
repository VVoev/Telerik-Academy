using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DogLovesPaper
{
    public class Program
    {
        public static void Main()
        {
            //var line = Console.ReadLine().Split(' ');
            //int nodesCount = int.Parse(line[0]);
            //var edgesCount = int.Parse(line[1]);
            var result = TopologicalSort();
            Console.WriteLine(string.Join("", result));
        }

        static Dictionary<int, TopoNode> ReadDirectedGraph()
        {
            // var n = int.Parse(Console.ReadLine());
            // var m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            var vertices = new Dictionary<int, TopoNode>();

            for (var i = 0; i < n; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ');

                var x = edge[2] == "before" ? int.Parse(edge[0]) : int.Parse(edge[3]);
                var y = edge[2] == "before" ? int.Parse(edge[3]) : int.Parse(edge[0]);

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

            var topSource = sources.Top;
            bool isFirst = true;

            while (sources.Count > 0)
            {
                var source = sources.Dequeue();

                if (isFirst)
                {
                    if (source == 0 && sources.Count > 0)
                    {
                        var newSource = sources.Dequeue();
                        sources.Enqueue(source);
                        source = newSource;
                    }

                    isFirst = false;
                }

                result.Add(source);
                var newSources = graph[source].Children;
                graph.Remove(source);
                UpdateSources(graph, newSources, sources);
            }

            return result;
        }

        private static void UpdateSources(Dictionary<int, TopoNode> graph, LinkedList<int> newSources, PriorityQueue<int> sources)
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

        private static PriorityQueue<int> ExtractSources(Dictionary<int, TopoNode> graph)
        {
            var queue = new PriorityQueue<int>();
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

        public class PriorityQueue<T>
      where T : IComparable<T>
        {
            private List<T> heap;
            private Func<T, T, bool> compare;

            public PriorityQueue()
            {
                this.heap = new List<T>
            {
                default(T)
            };

                this.compare = (x, y) => x.CompareTo(y) < 0;
            }

            public T Top
            {
                get
                {
                    return this.heap[1];
                }
            }
            public int Count
            {
                get
                {
                    return this.heap.Count - 1;
                }
            }
            public bool IsEmpty
            {
                get
                {
                    return this.Count == 0;
                }
            }

            public void Enqueue(T value)
            {
                var index = heap.Count; // index where inserted
                heap.Add(value);

                while (index > 1 && compare(value, heap[index / 2]))
                {
                    heap[index] = heap[index / 2];
                    index /= 2;
                }

                heap[index] = value;
            }

            public T Dequeue()
            {
                var toReturn = heap[1];
                var value = heap[heap.Count - 1];
                heap.RemoveAt(heap.Count - 1);

                if (!this.IsEmpty)
                {
                    this.HeapifyDown(1, value);
                }

                return toReturn;
            }

            private void HeapifyDown(int index, T value)
            {
                while (index * 2 + 1 < heap.Count)
                {
                    var smallerKidIndex = compare(heap[index * 2], heap[index * 2 + 1])
                        ? index * 2
                        : index * 2 + 1;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                    else
                    {
                        break;
                    }
                }

                if (index * 2 < heap.Count)
                {
                    var smallerKidIndex = index * 2;
                    if (compare(heap[smallerKidIndex], value))
                    {
                        heap[index] = heap[smallerKidIndex];
                        index = smallerKidIndex;
                    }
                }

                heap[index] = value;
            }
        }
    }
}