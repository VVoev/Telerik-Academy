using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendsInNedd
{
    class Program
    {
        static void Main(string[] args)
        {
            var line = Console.ReadLine().Split(' ');
            int nodesCount = int.Parse(line[0]);
            int edgesCount = int.Parse(line[1]);
            int hospitalsCount = int.Parse(line[2]);

            var h = Console.ReadLine().Split(' ');
            var hospitals = new List<int>();
            foreach (var hosp in h)
            {
                hospitals.Add(int.Parse(hosp));
            }

            int minSum = int.MaxValue;
            var vertices = ReadGraph(nodesCount, edgesCount);
            foreach (var hospital in hospitals)
            {
                minSum = Math.Min(minSum, Dijkstra(hospital, vertices, hospitals));
            }

            Console.WriteLine(minSum);
        }

        public static List<Node>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new List<Node>[nodesCount + 1];
            for (int i = 0; i < edgesCount; i++)
            {
                var edgeParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                AddEdge(graph, edgeParts[0], edgeParts[1], edgeParts[2]);
                AddEdge(graph, edgeParts[1], edgeParts[0], edgeParts[2]);
            }

            return graph;
        }

        public static void AddEdge(List<Node>[] graph, int from, int to, int weight)
        {
            if (graph[from] == null)
            {
                graph[from] = new List<Node>();
            }

            graph[from].Add(new Node(to, weight));
        }


        private static int Dijkstra(int start, List<Node>[] vertices, List<int> hospitals)
        {
            var distances = new int[vertices.Length];
            for (int i = 0; i < vertices.Length; i++)
            {
                distances[i] = int.MaxValue;
            }

            distances[start] = 0;

            var used = new bool[vertices.Length];

            var q = new PriorityQueue<Node>();

            q.Enqueue(new Node(start, 0));

            while (q.Count != 0)
            {
                var node = q.Dequeue();

                if (used[node.Vertex] == true)
                {
                    continue;
                }

                used[node.Vertex] = true;

                foreach (var next in vertices[node.Vertex])
                {
                    var currentDistance = distances[next.Vertex];
                    var newDistance = distances[node.Vertex] + next.Distance;

                    if (newDistance < currentDistance)
                    {
                        distances[next.Vertex] = newDistance;
                        q.Enqueue(new Node(next.Vertex, newDistance));
                    }
                }
            }

            for (int i = 0; i < hospitals.Count; i++)
            {
                distances[hospitals[i]] = 0;
            }

            int sum = 0;
            for (int i = 1; i < distances.Length; i++)
            {
                sum += distances[i];
            }

            return sum;
        }
    }

    public class Node : IComparable<Node>
    {
        public Node(int vertex, int distance)
        {
            this.Vertex = vertex;
            this.Distance = distance;
        }

        public int Distance { get; set; }

        public int Vertex { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
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
