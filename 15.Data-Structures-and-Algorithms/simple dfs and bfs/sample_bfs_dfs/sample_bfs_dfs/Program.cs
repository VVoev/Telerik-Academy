using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_bfs_dfs
{
    class Program
    {
        public static Node provideGraph()
        {
            Node root = new Node("A",
                                new Node("B",
                                    new Node("C"), new Node("D",
                                                        new Node("K"), new Node("L",
                                                                            new Node("Z"), new Node("ZA")))),
                                new Node("E",
                                    new Node("F"), new Node("G",
                                                        new Node("H"), null)));
            return root;
        }


        static void Main(string[] args)
        {

            Node graph = provideGraph();
            bfs(graph);
            dfs(graph);

            var arr = new int[] { 10, 8, 6, 4, 2, 1, 3, 5, 7, 2, 9 };
            findDublicated(arr);
            findWithHashSet(arr);
        }

        public static void MakeSpaces(Action <string> action,string input)
        {
            action(input);
        }


        private static void Intro(string v)
        {
            Console.WriteLine($@"------------------------{v}-----------------------");
        }

        private static void findWithHashSet(int[] arr)
        {
            var set = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var notFound =  set.Add(arr[i]);
                if (!notFound)
                {
                    Console.WriteLine(arr[i]);
                }
            }
        }

        private static void findDublicated(int[] arr)
        {
            var count = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (count[arr[i]] == 1)
                    Console.WriteLine((arr[i] + " "));
                else
                    count[arr[i]]++;
            }

        }

        private static void dfs(Node node)
        {
            if (node == null)
            {
                return;
            }
            Console.WriteLine(node.Data);
            dfs(node.Right);
            dfs(node.Left);
        }

        private static void bfs(Node node)
        {
            Queue<Node> q = new Queue<Node>();
            q.Enqueue(node);

            while (q.Count > 0)
            {
                node = q.Dequeue();
                Console.WriteLine("Current Node" + node.Data);

                if (node.Left != null)
                {
                    q.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    q.Enqueue(node.Right);
                }
            }

        }
    }
}
