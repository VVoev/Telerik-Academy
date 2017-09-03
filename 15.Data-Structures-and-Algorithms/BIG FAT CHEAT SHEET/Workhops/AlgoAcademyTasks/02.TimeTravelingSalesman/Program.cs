using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpanningTrees
{
    partial class Edge : IComparable<Edge>
    {
        public Edge(int x, int y, int weight)
        {
            X = x;
            Y = y;
            this.Weight = weight;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            return this.Weight.CompareTo(other.Weight);
        }

        public override string ToString()
        {
            return $"{this.X} -> {this.Y} ({this.Weight})";
        }
    }


    partial class SpanningTreesDemos
    {
        class Node
        {
            public Node(int vertex, int weight)
            {
                Vertex = vertex;
                Weight = weight;
            }

            public int Vertex { get; set; }

            public int Weight { get; set; }
        }
    }

    partial class SpanningTreesDemos
    {
        static void Main()
        {
            //var vertices = ReadGraphAsList();
            int n;
            var edges = ReadGraphAsListOfEdges(out n);

            var mst = FindMinimumSpanningTreeKruskal(edges, n);
            //var mst = FindMinimumSpanningTreePrim(vertices);
            Console.WriteLine(mst.Sum(x => x.Weight));
        }

        static int Find(List<int> trees, int vertex)
        {
            if (trees[vertex] == -1)
            {
                return vertex;
            }

            trees[vertex] = Find(trees, trees[vertex]);
            return trees[vertex];
        }

        private static List<Edge> FindMinimumSpanningTreeKruskal(PriorityQueue<Edge> edges, int n)
        {
            var trees = Enumerable.Range(1, n + 1)
                .Select(_ => -1)
                .ToList();

            var result = new List<Edge>();

            while (edges.IsEmpty == false)
            {
                var edge = edges.Dequeue();

                if (Find(trees, edge.X) == Find(trees, edge.Y))
                {
                    continue;
                }

                result.Add(edge);

                trees[Find(trees, edge.X)] = Find(trees, edge.Y);

            }
            return result;
        }

        private static List<Edge> FindMinimumSpanningTreePrim(List<Node>[] vertices)
        {
            var tree = new HashSet<int>();
            var mst = new List<Edge>();
            var edges = new PriorityQueue<Edge>();
            
            var vertex = 1;

            do
            {
                tree.Add(vertex);
                // add edges from vertex
                foreach (var next in vertices[vertex])
                {
                    edges.Enqueue(new Edge(vertex, next.Vertex, next.Weight));
                }

                // find best
                Edge edge = FindNextBest(tree, edges);
                if (edge == null)
                {
                    break;
                }

                vertex = tree.Contains(edge.X)
                    ? edge.Y
                    : edge.X;
                //sum += edge.Weight;
                mst.Add(edge);
            } while (edges.IsEmpty == false);
            //return sum;
            return mst;
        }

        private static Edge FindNextBest(HashSet<int> tree, PriorityQueue<Edge> edges)
        {
            if (edges.IsEmpty)
            {
                return null;
            }

            Edge edge = edges.Dequeue();

            var vertex = tree.Contains(edge.X)
                ? edge.Y
                : edge.X;

            while (tree.Contains(vertex))
            {
                if (edges.IsEmpty)
                {
                    return null;
                }

                edge = edges.Dequeue();
                vertex = tree.Contains(edge.X)
                    ? edge.Y
                    : edge.X;
            }

            return edge;
        }

        private static List<Node>[] ReadGraphAsList()
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var vertices = new List<Node>[n + 1];

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                AddEdge(vertices, edge[0], edge[1], edge[2]);
                AddEdge(vertices, edge[1], edge[0], edge[2]);
            }

            return vertices;
        }

        private static PriorityQueue<Edge> ReadGraphAsListOfEdges(out int n)
        {
            n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            var edges = new PriorityQueue<Edge>();

            for (var i = 0; i < m; i++)
            {
                var edge = Console.ReadLine()
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                var edge1 = new Edge(edge[0], edge[1], edge[2]);
                var edge2 = new Edge(edge[1], edge[0], edge[2]);
                edges.Enqueue(edge1);
                edges.Enqueue(edge2);
            }

            return edges;
        }

        private static void AddEdge(List<Node>[] vertices, int from, int to, int weight)
        {
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }
            vertices[from].Add(new Node(to, weight));
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

        public T Top => heap[1];
        public int Count => heap.Count - 1;
        public bool IsEmpty => Count == 0;

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