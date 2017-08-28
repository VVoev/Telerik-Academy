using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mineGraph
{
    class Test
    {
        public static void RunDictionaryGraph()
        {
            var graph = new Dictionary<string, List<string>>();

            var line = Console.ReadLine();
            while(line != string.Empty)
            {
                string []connections = line.Split(' ');
                string first = connections[0];
                string second = connections[1];

                if (!graph.ContainsKey(first))
                {
                    graph[first] = new List<string>();
                }
                graph[first].Add(second);

                if(first != second)
                {
                    if (!graph.ContainsKey(second))
                    {
                        graph[second] = new List<string>();
                    }
                    graph[second].Add(first);
                }


                line = Console.ReadLine();
            }

            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                foreach (string neighbors in node.Value)
                {
                    Console.Write(neighbors + " ");
                }

                Console.WriteLine();
            }
        }

        public static void RunSecondTask()
        {
            var arr = new string[] { "7 19", "7 21", "7 14", "19 1", "19 12", "19 31", "14 23", "14 6" };
            var possibleRoot = new HashSet<int>();
            var graph = new Dictionary<int,List<Node>>();

            for (int i = 0; i < arr.Length; i++)
            {
                var input = arr[i].Split(' ');
                var parrent = int.Parse(input[0]);
                var child = int.Parse(input[1]);

                var childNode = new Node(child);
                childNode.IsChild = true;
                if (!graph.ContainsKey(parrent))
                {
                    graph[parrent] = new List<Node>();
                }
                childNode.ParrentValue = parrent;
                graph[parrent].Add(childNode);
                possibleRoot.Add(parrent);
                possibleRoot.Add(child);
            }
            var root = FindRoot(graph,possibleRoot);
            Console.WriteLine($"Root {root}");

            Print(graph);
            
          
        }

        private static void Print(Dictionary<int, List<Node>> graph)
        {
            foreach (var node in graph)
            {
                Console.Write(node.Key + " -> ");

                foreach (var neighbors in node.Value)
                {
                    Console.Write(neighbors + " ");
                }

                Console.WriteLine();
            }
        }

        private static int FindRoot(Dictionary<int, List<Node>> graph, HashSet<int>possibleRoot)
        {
            foreach (var parent in graph)
            {
                foreach (var b in parent.Value)
                {
                    if (possibleRoot.Contains(b.Value))
                    {
                        possibleRoot.Remove(b.Value);
                    }
                }
            }
            var root = 0;
            foreach (var item in possibleRoot)
            {
                root = item;
            }
            return root;
        }

        public class Node
        {
            public int Value { get; set; }
            private bool isChild =false;

            public bool IsChild
            {
                get
                {
                    return this.isChild;
                }
                set
                {
                    this.isChild = value;
                }
                
            }
            public int ParrentValue { get; set; }

            public Node(int value)
            {
                this.Value = value;
                this.IsChild = false;
            }

            public override string ToString()
            {
                return $"{this.Value}";
            }
        }
    }
}
