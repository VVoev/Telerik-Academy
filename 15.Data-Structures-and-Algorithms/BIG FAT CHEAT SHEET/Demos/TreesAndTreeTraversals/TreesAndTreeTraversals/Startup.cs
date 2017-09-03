using System;
using System.Collections.Generic;
using TreesAndTreeTraversals.HeapSort;
using TreesAndTreeTraversals.IndexedTrees;
using TreesAndTreeTraversals.Tree;

namespace TreesAndTreeTraversals
{
    public class Startup
    {
        public static void Main()
        {
            //var tree = new TreeNode<int>(20,
            //    new TreeNode<int>(44,
            //        new TreeNode<int>(17), new TreeNode<int>(41)),
            //    new TreeNode<int>(02,
            //           new TreeNode<int>(99), new TreeNode<int>(97)));

            // DFS(tree);
            // BFS(tree);
            //DFSWithStack(tree);

            //var array = new int[10];
            //var random = new Random();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    array[i] = random.Next() % 100;
            //}

            //Console.WriteLine(string.Join(" ", array));
            //var heap = new BinaryHeap.BinaryHeap<int>((a, b) => a > b);

            //foreach (var element in array)
            //{
            //    heap.Insert(element);
            //    Console.Write(heap.GetTop() + " ");
            //}

            //Console.WriteLine();

            //for (int i  =0; i < array.Length; i++)
            //{
            //    array[i] = heap.GetTop();
            //    heap.RemoveTop();
            //}

            //Console.WriteLine(string.Join(" ", array));

            //var array = new int[10];
            //var random = new Random();
            //for (int i =0; i < array.Length; i++)
            //{
            //    array[i] = random.Next() % 100;
            //}

            //array.HeapSort((a, b) => a > b);

            var list = new List<int>();
            list.Add(3);
            list.Add(4);
            list.Add(5);

            var indexedTree = new BinaryIndexedTree<int>(list, (a, b) => a + b);
            Console.WriteLine(indexedTree.GetInterval(0, 3));
        }

        public static void DFS<T>(TreeNode<T> treeNode)
        {
            if (treeNode == null)
            {
                return;
            }

            Console.WriteLine(treeNode.Value);

            DFS(treeNode.Left);
            DFS(treeNode.Right);
        }

        public static void DFSWithStack<T>(TreeNode<T> treeNode)
        {
            var stack = new Stack<TreeNode<T>>();
            stack.Push(treeNode);

            while (stack.Count > 0)
            {
                var currentNode = stack.Pop();
                Console.WriteLine(currentNode.Value);

                if (currentNode.Right != null)
                {
                    stack.Push(currentNode.Right);
                }

                if (currentNode.Left != null)
                {
                    stack.Push(currentNode.Left);
                }

            }
        }

        public static void BFS<T>(TreeNode<T> treeNode)
        {
            var queue = new Queue<TreeNode<T>>();
            queue.Enqueue(treeNode);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Peek().Value);

                var currentNode = queue.Dequeue();
                if (currentNode.Left != null)
                {
                    queue.Enqueue(currentNode.Left);
                }

                if (currentNode.Right != null)
                {
                    queue.Enqueue(currentNode.Right);
                }
            }
        }
    }
}
