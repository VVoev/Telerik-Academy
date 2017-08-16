using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpanningTrees
{
    partial class SpanningTreesDemos
    {

        private static string input = @"5
8
5 2 15
3 4 2
5 3 6
2 3 3
1 3 3
1 2 2
4 5 3
1 4 11";

        static void FakeInput()
        {
            Console.SetIn(new StringReader(input));
        }

        static void Main()
        {
            FakeInput();
            //var vertices = ReadGraphAsList();
            int n;
            var edges = ReadGraphAsListOfEdges(out n);

            var mst = FindMinimumSpanningTreeKruskal(edges, n);
            //var mst = FindMinimumSpanningTreePrim(vertices);
            Console.WriteLine(string.Join("\n ", mst));
            //Console.WriteLine(mst);
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
            //result.Add(new Edge(1, 4, 11));
            //trees[1] = 4;

            while (edges.IsEmpty == false)
            {
                var edge = edges.Dequeue();

                if (Find(trees, edge.X) == Find(trees, edge.Y))
                {
                    continue;
                }

                result.Add(edge);

                trees[Find(trees, edge.X)] = Find(trees, edge.Y);

                /* Slow */
                //var rootX = trees[edge.X] < 0
                //    ? edge.X
                //    : trees[edge.X];

                //var rootY = trees[edge.Y] < 0
                //    ? edge.Y
                //    : trees[edge.Y];

                //if (rootX > -1 &&
                //        rootX == rootY)
                //{
                //    continue;
                //}

                //result.Add(edge);

                //for (var i = 0; i < trees.Count; i++)
                //{
                //    if (trees[i] == rootY)
                //    {
                //        trees[i] = rootX;
                //    }
                //}

                //trees[rootY] = rootX;
            }
            return result;
        }

        private static List<Edge> FindMinimumSpanningTreePrim(List<Node>[] vertices)
        {
            var tree = new HashSet<int>();
            var mst = new List<Edge>();
            var edges = new PriorityQueue<Edge>();

            // If we want a concrete edge to be included in the tree
            //tree.Add(1);
            //tree.Add(4);
            //vertices[1]
            //        .ForEach(next => edges.Enqueue(new Edge(1, next.Vertex, next.Weight)));
            //vertices[4]
            //    .ForEach(next => edges.Enqueue(new Edge(4, next.Vertex, next.Weight)));
            //mst.Add(new Edge(1, 4, 11));

            //var sum = 0;

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
}
