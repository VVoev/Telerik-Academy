namespace Kruskal
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static int busWeight;

        public static void Main()
        {
            var line = Console.ReadLine().Split(' ');
            

            int numberOfNodes = int.Parse(line[0]);
            int numberOfEdges = int.Parse(line[1]);

            List<Edge> edges = new List<Edge>();

            InitializeGraph(edges, numberOfEdges);
            busWeight = int.Parse(Console.ReadLine());
            edges.Sort();

            int[] tree = new int[numberOfNodes + 1]; //we start from 1, not from 0
            var mpd = new List<Edge>();
            int treesCount = 1;

            int result = 0;
            treesCount = FindMinimumSpanningTree(edges, tree,treesCount, ref result);

            Console.WriteLine(result);
        }

        private static int FindMinimumSpanningTree(List<Edge> edges, int[] tree, int treesCount, ref int result)
        {
            foreach (var edge in edges)
            {
                if (tree[edge.StartNode] == 0) // not visited
                {
                    if (tree[edge.EndNode] == 0) // both ends are not visited
                    {
                        tree[edge.StartNode] = tree[edge.EndNode] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[edge.StartNode] = tree[edge.EndNode];
                    }
                    if (edge.Weight < busWeight)
                    {
                        result++;
                    }
                }
                else // the start is part of a tree
                {
                    if (tree[edge.EndNode] == 0)
                    {
                        //attach the end node to the tree;
                        tree[edge.EndNode] = tree[edge.StartNode];
                        if (edge.Weight < busWeight)
                        {
                            result++;
                        }
                    }
                    else if (tree[edge.EndNode] != tree[edge.StartNode]) // combine the trees
                    {
                        int oldTreeNumber = tree[edge.EndNode];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[edge.StartNode];
                            }
                        }

                        if (edge.Weight < busWeight)
                        {
                            result++;
                        }                  
                    }
                }
            }
            return treesCount;
        }

        private static void InitializeGraph(List<Edge> edges, int edgesCount)
        {
            for (int i = 0; i < edgesCount; i++)
            {
                var line = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                edges.Add(new Edge(line[0], line[1], line[2]));
                edges.Add(new Edge(line[1], line[0], line[2]));
            }
        }
    }

    public class Edge : IComparable<Edge>
    {
        public Edge(int startNode, int endNode, int weight)
        {
            this.StartNode = startNode;
            this.EndNode = endNode;
            this.Weight = weight;
        }

        public int StartNode { get; set; }

        public int EndNode { get; set; }

        public int Weight { get; set; }

        public int CompareTo(Edge other)
        {
            int weightCompared = other.Weight.CompareTo(this.Weight);
            if (weightCompared == 0)
            {
                return this.StartNode.CompareTo(other.StartNode);
            }

            return weightCompared;
        }
    }
}