using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01.FriendsOfPesho
{
    public class Startup
    {
        public static void Main()
        {
            var nodesAndEdges = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var nodesCount = nodesAndEdges[0];
            var edgesCount = nodesAndEdges[1];

            var targetNodes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int startNode = targetNodes[0];
            int endNode = targetNodes[1];

            var middleNodes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var firstMiddleNode = middleNodes[0];
            var secondMiddleNode = middleNodes[1];

            var graph = ReadGraph(nodesCount, edgesCount);

            var fromStartNodeDistnaces = GetShortestPathTo(graph, startNode);
            var fromFirstMiddleDistances = GetShortestPathTo(graph, firstMiddleNode);
            var fromSecondMiddleDistances = GetShortestPathTo(graph, secondMiddleNode);

            var firstWayDistance = fromStartNodeDistnaces[firstMiddleNode] + fromFirstMiddleDistances[secondMiddleNode] + fromSecondMiddleDistances[endNode];
            var secondWayDistance = fromStartNodeDistnaces[secondMiddleNode] + fromSecondMiddleDistances[firstMiddleNode] + fromFirstMiddleDistances[endNode];

            Console.WriteLine(firstWayDistance < secondWayDistance ? firstWayDistance : secondWayDistance);
        }

        public static int[] GetShortestPathTo(LinkedList<Edge>[] graph, int startNode)
        {
            var queue = new PriorityQueue<Edge>();
            var visited = new bool[graph.Length];
            var distances = new int[graph.Length].Select(_ => int.MaxValue).ToArray();

            distances[startNode] = 0;
            queue.Enqueue(new Edge(startNode, 0));

            while (!queue.IsEmpty)
            {
                var currentNode = queue.Dequeue();
                visited[currentNode.Target] = true;

                foreach (var successor in graph[currentNode.Target])
                {
                    if (visited[successor.Target])
                    {
                        continue;
                    }

                    var newDistance = distances[currentNode.Target] + successor.Weight;
                    var currentDistance = distances[successor.Target];
                    if (currentDistance > newDistance)
                    {
                        distances[successor.Target] = newDistance;
                        queue.Enqueue(new Edge(successor.Target, newDistance));
                    }
                }
            }

            return distances;
        }

        private static LinkedList<Edge>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new LinkedList<Edge>[nodesCount + 1];

            for (int i = 0; i < edgesCount; i++)
            {
                var connection = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var from = connection[0];
                var to = connection[1];
                var weight = connection[2];

                AddEdge(graph, from, to, weight);
            }

            return graph;
        }

        private static void AddEdge(LinkedList<Edge>[] graph, int from, int to, int weight)
        {
            if (graph[from] == null)
            {
                graph[from] = new LinkedList<Edge>();
            }

            if (graph[to] == null)
            {
                graph[to] = new LinkedList<Edge>();
            }

            graph[from].AddLast(new Edge(to, weight));
            graph[to].AddLast(new Edge(from, weight));
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
