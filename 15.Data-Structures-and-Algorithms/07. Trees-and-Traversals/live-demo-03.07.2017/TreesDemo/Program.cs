using System;
using System.Collections.Generic;
using BinaryHeap;
using IndexedTrees;
using System.Diagnostics;
using UnionFindStructure;

namespace TreesDemo
{
    using System.Numerics;
    using Node = Tree<int>;

    public class Program
    {
        static int SumDigits(int x)
        {
            return x / 10 + x % 10;
        }
        static void Main()
        {
            var uf = new UnionFind(10);

            while(true)
            {
                uf.Print();

                var strs = Console.ReadLine().Split(' ');
                if (strs[0] == "f")
                {
                    int x = int.Parse(strs[1]);
                    Console.WriteLine(uf.Find(x));
                }
                else if (strs[0] == "u")
                {
                    int x = int.Parse(strs[1]);
                    int y = int.Parse(strs[2]);
                    Console.WriteLine(uf.Union(x, y));
                }
            }
        }

        static void Dfs<T>(Tree<T> root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine($"entering {root.Value}");
            Dfs(root.Left);
            Console.WriteLine($"in between {root.Value}");
            Dfs(root.Right);
            Console.WriteLine($"leaving {root.Value}");
        }

        static void Bfs<T>(Tree<T> root)
        {
            var q = new Queue<Tree<T>>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var x = q.Dequeue();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    q.Enqueue(x.Left);
                }
                if (x.Right != null)
                {
                    q.Enqueue(x.Right);
                }
            }
        }

        static void DfsWithStack<T>(Tree<T> root)
        {
            var q = new Stack<Tree<T>>();
            q.Push(root);

            while (q.Count > 0)
            {
                var x = q.Pop();
                Console.WriteLine(x.Value);
                if (x.Left != null)
                {
                    q.Push(x.Left);
                }
                if (x.Right != null)
                {
                    q.Push(x.Right);
                }
            }
        }

        static BigInteger Ackermann(int m, BigInteger n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            if(n == 0)
            {
                return Ackermann(m - 1, 1);
            }
            return Ackermann(m - 1, Ackermann(m, n - 1));
        }
    }
}
