using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.FriendsOfPesho
{
    public class Startup
    {
        static int[] distances;

        public static void Main()
        {
            var nodesAndEdgesAndHospitals = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var nodesCount = nodesAndEdgesAndHospitals[0];
            var edgesCount = nodesAndEdgesAndHospitals[1];
        
            var hospitals = new HashSet<int>();
            Console.ReadLine().Split(' ').ToList().ForEach((a) => hospitals.Add(int.Parse(a)));

            var graph = ReadGraph(nodesCount, edgesCount);
            int minPath = int.MaxValue;

            distances = new int[graph.Length];
            foreach (var hospital in hospitals)
            {
                GetShortestPathTo(graph, hospital);
                int currentPath = 0;
                for (int i = 1; i < distances.Length; i++)
                {
                    if (!hospitals.Contains(i))
                    {
                        currentPath += distances[i];
                    }
                }

                if (currentPath < minPath)
                {
                    minPath = currentPath;
                }
            }

            Console.WriteLine(minPath);
        }

        public static void GetShortestPathTo(LinkedList<Edge>[] graph, int startNode)
        {
            var used = new HashSet<int>();
            distances = distances.Select(_ => int.MaxValue).ToArray();
            distances[startNode] = 0;
            var queue = new PriorityQueue<Edge>();
            queue.Enqueue(new Edge(startNode, 0));

            while (!queue.IsEmpty)
            {
                var bestNode = queue.Dequeue();
                while (!queue.IsEmpty && used.Contains(bestNode.Target))
                {
                    bestNode = queue.Dequeue();
                }

                used.Add(bestNode.Target);

                foreach (var next in graph[bestNode.Target])
                {
                    var currentDistance = distances[next.Target];
                    var newDistance = distances[bestNode.Target] + next.Weight;

                    if (currentDistance <= newDistance)
                    {
                        continue;
                    }

                    distances[next.Target] = newDistance;
                    queue.Enqueue(new Edge(next.Target, newDistance));
                }
            }
        }

        private static LinkedList<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new LinkedList<Edge>[nodesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                var connection = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var from = connection[0];
                var to = connection[1];
                var weight = connection[2];

                AddEdge(graph, from, to, weight);
                AddEdge(graph, to, from, weight);
            }

            return graph;
        }

        private static void AddEdge(LinkedList<Edge>[] graph, int from, int to, int weight)
        {
            if (graph[from] == null)
            {
                graph[from] = new LinkedList<Edge>();
            }

            graph[from].AddLast(new Edge(to, weight));
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int target, int weight)
        {
            this.Target = target;
            this.Weight = weight;
        }

       public int Weight { get; set; }

       public int Target { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
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
                return this. heap.Count - 1;
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