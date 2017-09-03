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
            var hospitals = new HashSet<int>();
            foreach (var hosp in h)
            {
                hospitals.Add(int.Parse(hosp));
            }

            var graph = ReadGraph(nodesCount, edgesCount);
            long min = int.MaxValue;
            foreach (var hospital in hospitals)
            {
                var paths = FindShortestPathsFrom(graph, hospital);
                int currentPathValue = 0;
                for (int i = 1; i < graph.Length; i++)
                {
                    if (!hospitals.Contains(i))
                    {
                        currentPathValue += paths[i];
                    }
                }

                if (currentPathValue < min)
                {
                    min = currentPathValue;
                }
            }

            Console.WriteLine(min);
        }

        public static void PrintGraph(LinkedList<Node>[] graph)
        {
            for (int i = 1; i < graph.Length; i++)
            {
                Console.WriteLine(string.Format("{0} => {1}",i, string.Join("; ", graph[i])));
            }
        }

        public static int[] FindShortestPathsFrom(LinkedList<Node>[] graph, int startIndex)
        {
            var paths = new int[graph.Length];
            var visited = new HashSet<int>();
            for (int i = 1; i < paths.Length; i++)
            {
                paths[i] = int.MaxValue;
            }

            paths[startIndex] = 0;
            var queue = new PriorityQueue<Node>();
            queue.Enqueue(new Node(startIndex, 0));

            while (!queue.IsEmpty)
            {
                var currentNode = queue.Dequeue();
                while (!queue.IsEmpty && visited.Contains(currentNode.Target))
                {
                    currentNode = queue.Dequeue();
                }
               
                visited.Add(currentNode.Target);

                foreach (var next in graph[currentNode.Target])
                {
                    if (visited.Contains(next.Target))
                    {
                        continue;
                    }

                    var currentDistance = paths[next.Target];
                    var newDistance = paths[currentNode.Target] + next.Weight;

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }

                    paths[next.Target] = newDistance;
                    queue.Enqueue(new Node(next.Target, newDistance));
                }
            }

            return paths;
        }

        public static LinkedList<Node>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new LinkedList<Node>[nodesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeParts = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                AddEdge(graph, edgeParts[0], edgeParts[1], edgeParts[2]);
                AddEdge(graph, edgeParts[1], edgeParts[0], edgeParts[2]);
            }

            return graph;
        }

        public static void AddEdge(LinkedList<Node>[] graph, int from, int to, int weight)
        {
            if (graph[from] == null)
            {
                graph[from] = new LinkedList<Node>();
            }

            graph[from].AddLast(new Node(to, weight));
        }

        public class Node : IComparable<Node>
        {
            public Node(int target, int weight)
            {
                this.Target = target;
                this.Weight = weight;
            }

            public int Target { get; set; }

            public int Weight { get; set; }

            public int CompareTo(Node other)
            {
                return this.Weight.CompareTo(other.Weight);
            }

            public override string ToString()
            {
                return this.Target + " " + this.Weight;
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
                    return heap[1];
                }
            }
            public int Count
            {
                get
                {
                    return heap.Count - 1;
                }
            }

            public bool IsEmpty
            {
                get
                {
                    return Count == 0;
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
