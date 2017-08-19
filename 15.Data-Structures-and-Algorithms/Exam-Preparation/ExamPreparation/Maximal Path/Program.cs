using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace _1._1_MaximalPathBest
{
    class Program
    {
        static bool DEBUG = true;

        static Dictionary<int, List<int>> tree;
        static Dictionary<int, bool> visited;
        static int farthestNode = 0;
        static long farthestNodeTotal = 0;
        static long max = 0;
        static void Main(string[] args)
        {
            Input();
            int someNode = tree.First((h) => h.Key > 0).Key;
            FindFarthestNode(someNode, 0);
            DFS(farthestNode, farthestNode);
            Console.WriteLine(max);
        }

        private static void DFS(int fromRoot, long total)
        {
            visited[fromRoot] = true;

            foreach (var descendant in tree[fromRoot])
            {
                if (!visited[descendant])
                {
                    DFS(descendant, total + descendant);
                }
            }

            visited[fromRoot] = false;

            max = total > max ? total : max;
        }

        private static void FindFarthestNode(int node, long total)
        {
            visited[node] = true;

            foreach (var descendant in tree[node])
            {

                if (!visited[descendant])
                {

                    FindFarthestNode(descendant, total + descendant);
                }
            }

            visited[node] = false;

            if (total > farthestNodeTotal)
            {
                farthestNodeTotal = total;
                farthestNode = node;
            }
            if (DEBUG)
            {
                Console.WriteLine("{0} : {1}", node, farthestNode);
            }
        }

        private static void Input()
        {
            int nodeCount = int.Parse(Console.ReadLine());
            tree = new Dictionary<int, List<int>>(nodeCount);
            visited = new Dictionary<int, bool>(nodeCount);

            for (int i = 0; i < nodeCount - 1; i++)
            {
                string line = Console.ReadLine();
                string[] vals = line.Trim('(', ')').Split(new string[1] { "<-" }, StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(vals[1]);
                int parentOfNode = int.Parse(vals[0]);

                if (!tree.ContainsKey(parentOfNode))
                {
                    tree.Add(parentOfNode, new List<int>());
                }
                if (!tree.ContainsKey(node))
                {
                    tree.Add(node, new List<int>());
                }

                if (!visited.ContainsKey(node))
                {
                    visited.Add(node, false);
                }
                if (!visited.ContainsKey(parentOfNode))
                {
                    visited.Add(parentOfNode, false);
                }

                tree[parentOfNode].Add(node);
                tree[node].Add(parentOfNode);
            }
        }
    }
}