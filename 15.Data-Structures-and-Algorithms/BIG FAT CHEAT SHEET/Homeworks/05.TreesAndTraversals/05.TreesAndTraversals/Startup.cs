using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TreesAndTraversals
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var nodes = new TreeNode[n];

            for (int i = 0; i < n; i++)
            {
                nodes[i] = new TreeNode(i);
            }

            var havingParent = new bool[n];
            for (int i = 0; i < n - 1; i++)
            {
                var pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                nodes[pair[0]].Children.Add(nodes[pair[1]]);
                havingParent[pair[1]] = true;
            }

            // 1. Find root element
            var root = FindRoot(nodes, havingParent);
            //Console.WriteLine(root.Value);

            // 2. Find leaves
            var leafs = FindLeafs(nodes);
            //leafs.ToList().ForEach(l => Console.Write(l.Value + " "));

            // 3. Find middle elements
            var middleElements = FindMiddleElements(nodes, root);
            //middleElements.ToList().ForEach(m => Console.Write(m.Value + " "));

            // 4. Find max path length in the tree
            var maxPathLength = FindLongestPath(root);
            // Console.WriteLine(maxPathLength);

            // 5. find  all paths with sum S
            int targetSum = 8;
            var paths = FindPathsWithSumS(root, targetSum);
            //Console.WriteLine(string.Join(Environment.NewLine, paths));

            // 6. find all substrees with sum s          
            var subtreesPaths = FindSubtreesWithSumS(nodes, int.Parse(Console.ReadLine()));
            Console.WriteLine(string.Join(Environment.NewLine, subtreesPaths));
        }

        public static List<string> FindSubtreesWithSumS(TreeNode[] nodes, int targetSum)
        {
            var resultSubtrees = new List<string>();
            var currentNodeSubtrees = new List<int>();
            foreach (var node in nodes)
            {
                currentNodeSubtrees.Add(node.Value);
                FindSubtreesWithSumS(node, targetSum, currentNodeSubtrees, resultSubtrees);
                currentNodeSubtrees.Clear();
            }

            return resultSubtrees;
        }

        public static void FindSubtreesWithSumS(TreeNode node, int targetSum, List<int> currentSubtree, List<string> resultSubtrees)
        {
            if (currentSubtree.Sum() == targetSum)
            {
                resultSubtrees.Add(string.Join(" -> ", currentSubtree));
            }

            if (node.Children.Count == 0)
            {
                return;
            }

            foreach (var childNode in node.Children)
            {
                currentSubtree.Add(childNode.Value);
                FindSubtreesWithSumS(childNode, targetSum, currentSubtree, resultSubtrees);
                currentSubtree.RemoveAt(currentSubtree.Count - 1);
            }
        }

        public static void TraverseTree(TreeNode root, string indent)
        {
            Console.WriteLine(indent + root.Value);
            if (root.Children.Count == 0)
            {
                return;
            }

            foreach (var childNode in root.Children)
            {
                TraverseTree(childNode, indent + "   ");
            }
        }

        public static void FindPathsWithSumS(TreeNode node, int currentSum, int targetSum, string currentPath, List<string> paths)
        {
            if (node.Children.Count == 0 && node.Value + currentSum == targetSum)
            {
                currentPath += "->" + node.Value;
                paths.Add(currentPath);
            }

            foreach (var childNode in node.Children)
            {
                FindPathsWithSumS(childNode, currentSum + node.Value, targetSum, currentSum + "->" + node.Value, paths);
            }
        }

        public static List<string> FindPathsWithSumS(TreeNode root, int targetSum)
        {
            var paths = new List<string>();
            FindPathsWithSumS(root, 0, targetSum, string.Empty, paths);
            Console.WriteLine(string.Join(Environment.NewLine, paths));
            return paths;
        }

        public static TreeNode[] FindMiddleElements(TreeNode[] nodes, TreeNode root)
        {
            var middleNodes = new List<TreeNode>();
            foreach (var node in nodes)
            {
                if (node.Children.Count > 0 && node != root)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes.ToArray();
        }

        public static TreeNode[] FindLeafs(TreeNode[] nodes)
        {
            var leafs = new List<TreeNode>();
            foreach (var element in nodes)
            {
                if (element.Children.Count == 0)
                {
                    leafs.Add(element);
                }
            }

            return leafs.ToArray();
        }

        public static TreeNode FindRoot(TreeNode[] nodes, bool[] havingParent)
        {
            for (int i = 0; i < havingParent.Length; i++)
            {
                if (!havingParent[i])
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("No root element!");
        }

        public static int FindLongestPath(TreeNode node)
        {
            int maxLength = 0;
            foreach (var childNode in node.Children)
            {
                maxLength = Math.Max(maxLength, FindLongestPath(childNode));
            }

            return maxLength + 1;
        }
    }
}
