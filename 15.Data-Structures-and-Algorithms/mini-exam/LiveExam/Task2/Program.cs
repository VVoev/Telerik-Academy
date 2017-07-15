using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    public class PriorityQueue<T> where T : IComparable<T>
    {
        private T[] heap;
        private int index;

        public PriorityQueue()
        {
            this.heap = new T[16];
            this.index = 1;
        }

        public int Count
        {
            get
            {
                return this.index - 1;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.Count == 0;
            }
        }

        public void Enqueue(T element)
        {
            if (this.index >= this.heap.Length)
            {
                this.IncreaseArray();
            }

            this.heap[this.index] = element;

            int childIndex = this.index;
            int parentIndex = childIndex / 2;
            this.index++;

            while (parentIndex >= 1 && this.heap[childIndex].CompareTo(this.heap[parentIndex]) < 0)
            {
                T swapValue = this.heap[parentIndex];
                this.heap[parentIndex] = this.heap[childIndex];
                this.heap[childIndex] = swapValue;

                childIndex = parentIndex;
                parentIndex = childIndex / 2;
            }
        }

        public T Dequeue()
        {
            T result = this.heap[1];

            this.heap[1] = this.heap[this.Count];
            this.index--;

            int rootIndex = 1;

            while (true)
            {
                int leftChildIndex = rootIndex * 2;
                int rightChildIndex = (rootIndex * 2) + 1;

                if (leftChildIndex > this.index)
                {
                    break;
                }

                int minChild;
                if (rightChildIndex > this.index)
                {
                    minChild = leftChildIndex;
                }
                else
                {
                    if (this.heap[leftChildIndex].CompareTo(this.heap[rightChildIndex]) < 0)
                    {
                        minChild = leftChildIndex;
                    }
                    else
                    {
                        minChild = rightChildIndex;
                    }
                }

                if (this.heap[minChild].CompareTo(this.heap[rootIndex]) < 0)
                {
                    T swapValue = this.heap[rootIndex];
                    this.heap[rootIndex] = this.heap[minChild];
                    this.heap[minChild] = swapValue;

                    rootIndex = minChild;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public T Peek()
        {
            return this.heap[1];
        }

        private void IncreaseArray()
        {
            var copiedHeap = new T[this.heap.Length * 2];

            for (int i = 0; i < this.heap.Length; i++)
            {
                copiedHeap[i] = this.heap[i];
            }

            this.heap = copiedHeap;
        }
    }

    class Node : IComparable<Node>
    {
        public int Vertex;

        public double Weight;

        public Node(int vertex, double weight)
        {
            this.Vertex = vertex;
            this.Weight = weight;
        }

        public int CompareTo(Node other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // // Read graph
            // int n = int.Parse(Console.ReadLine());
            // int m = int.Parse(Console.ReadLine());
            //
            // var vertices = new List<Node>[n];
            //
            // for (int i = 0; i < m; i++)
            // {
            //     var edge = Console.ReadLine().Split(' ')
            //                                 .Select(int.Parse)
            //                                  .ToArray();
            //     AddVertex(vertices, edge[0], edge[1], edge[2]);
            //     AddVertex(vertices, edge[1], edge[0], edge[2]);
            // }

            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            double[,] m = new double[row, col];

            for (int i = 0; i < row; i++)
            {
                var line = Console.ReadLine().Split(' ');
                for (int j = 0; j < col; j++)
                {
                    m[i, j] = double.Parse(line[j]);
                }
            }

            int n = row * col;
            var vertices = new List<Node>[n];
            int verticeN = 0;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i % 2 == 0)
                    {
                        vertices[verticeN] = new List<Node>();
                        double weight;
                        if (j - 1 >= 0)
                        {
                            var left = i * col + j - 1;
                            weight = Math.Abs(m[i, j] - m[i, j - 1]);
                            vertices[verticeN].Add(new Node(left, weight));
                        }

                        if (j + 1 < col)
                        {
                            var right = i * col + j + 1;
                            weight = Math.Abs(m[i, j] - m[i, j + 1]);
                            vertices[verticeN].Add(new Node(right, weight));
                        }

                        if (i - 1 >= 0)
                        {
                            var upper = (i - 1) * col + j;
                            weight = Math.Abs(m[i, j] - m[i - 1, j]);
                            vertices[verticeN].Add(new Node(upper, weight));
                        }

                        if (i + 1 < row)
                        {
                            var down = (i + 1) * col + j;
                            weight = Math.Abs(m[i, j] - m[i + 1, j]);
                            vertices[verticeN].Add(new Node(down, weight));
                        }

                        if (i - 1 >= 0 && j - 1 >= 0)
                        {
                            var upperLeft = (i - 1) * col + j - 1;
                            weight = Math.Abs(m[i, j] - m[i - 1, j - 1]);
                            vertices[verticeN].Add(new Node(upperLeft, weight));
                        }

                        if (i + 1 < row && j - 1 >= 0)
                        {
                            var downLeft = (i + 1) * col + j - 1;
                            weight = Math.Abs(m[i, j] - m[i + 1, j - 1]);
                            vertices[verticeN].Add(new Node(downLeft, weight));
                        }

                    }
                    else
                    {
                        vertices[verticeN] = new List<Node>();
                        double weight;
                        if (j - 1 >= 0)
                        {
                            var left = i * col + j - 1;
                            weight = Math.Abs(m[i, j] - m[i, j - 1]);
                            vertices[verticeN].Add(new Node(left, weight));
                        }

                        if (j + 1 < col)
                        {
                            var right = i * col + j + 1;
                            weight = Math.Abs(m[i, j] - m[i, j + 1]);
                            vertices[verticeN].Add(new Node(right, weight));
                        }

                        if (i - 1 >= 0)
                        {
                            var upper = (i - 1) * col + j;
                            weight = Math.Abs(m[i, j] - m[i - 1, j]);
                            vertices[verticeN].Add(new Node(upper, weight));
                        }

                        if (i + 1 < row)
                        {
                            var down = (i + 1) * col + j;
                            weight = Math.Abs(m[i, j] - m[i + 1, j]);
                            vertices[verticeN].Add(new Node(down, weight));
                        }

                        if (i - 1 >= 0 && j + 1 < col)
                        {
                            var upperRight = (i - 1) * col + j + 1;
                            weight = Math.Abs(m[i, j] - m[i - 1, j + 1]);
                            vertices[verticeN].Add(new Node(upperRight, weight));
                        }

                        if (i + 1 < row && j + 1 < col)
                        {
                            var downRight = (i + 1) * col + j + 1;
                            weight = Math.Abs(m[i, j] - m[i + 1, j + 1]);
                            vertices[verticeN].Add(new Node(downRight, weight));
                        }
                    }
                    verticeN++;
                }
            }

            // Dijkstra

            var distances = Dijkstra(vertices, n, 0);

            //Console.WriteLine($"{distances[n - 1]:f2}");
            Console.WriteLine(String.Format("{0:f2}", Math.Abs(distances[n - 1]) + Math.Abs(m[0, 0]) + Math.Abs(m[row - 1, col - 1])));

        }

        private static double[] Dijkstra(List<Node>[] vertices, int n, int start)
        {
            var d = new double[n];
            for (int i = 0; i < n; i++)
            {
                d[i] = double.MaxValue;
            }

            d[start] = 0;

            var used = new bool[n];

            var q = new PriorityQueue<Node>();

            q.Enqueue(new Node(start, 0));

            while (!q.IsEmpty)
            {
                var node = q.Dequeue();

                if (used[node.Vertex] == true)
                {
                    continue;
                }

                used[node.Vertex] = true;

                foreach (var next in vertices[node.Vertex])
                {
                    var currentDistance = d[next.Vertex];
                    var newDistance = d[node.Vertex] + next.Weight;

                    if (newDistance < currentDistance)
                    {
                        d[next.Vertex] = newDistance;
                        q.Enqueue(new Node(next.Vertex, newDistance));
                    }
                }
            }

            return d;
        }

        private static void AddVertex(List<Node>[] vertices, int from, int to, int weight)
        {
            var node = new Node(to, weight);
            if (vertices[from] == null)
            {
                vertices[from] = new List<Node>();
            }
            vertices[from].Add(node);
        }
    }
}