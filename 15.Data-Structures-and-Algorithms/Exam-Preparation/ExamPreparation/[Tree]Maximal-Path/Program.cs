namespace _Tree_Maximal_Path
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static string input = @"
10
(5 <- 11)
(1 <- 8)
(11 <- 3)
(8 <- 7)
(1 <- 5)
(11 <- 2)
(8 <- 6)
(2 <- 15)
(8 <- 4)
";
        static int maxSum = 0;
        static List<Node> usedNodes = new List<Node>();
        public static void DFS(Node node, int currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);
            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.getChildren(i)))
                {
                    continue;
                }
                DFS(node.getChildren(i), currentSum);
            }

            if (node.NumberOfChildren == 1 && maxSum > currentSum)
            {
                maxSum = currentSum;
            }
        }
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, Node> nodes = new Dictionary<int, Node>();

            for (int i = 0; i < n - 1; i++)
            {
                string connection = Console.ReadLine();
                string[] sepparatedConnection = connection.Split(new char[] { '-', '<', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

                int parent = int.Parse(sepparatedConnection[0]);
                int child = int.Parse(sepparatedConnection[1]);

                Node parrentNode;
                Node childNode;

                if (nodes.ContainsKey(parent))
                {
                    parrentNode = nodes[parent];
                }
                else
                {
                    parrentNode = new Node(parent);
                    nodes.Add(parent, parrentNode);
                }

                if (nodes.ContainsKey(child))
                {
                    childNode = nodes[child];
                }
                else
                {
                    childNode = new Node(child);
                    nodes.Add(child, childNode);
                }

                parrentNode.AddChild(childNode);
                childNode.AddChild(parrentNode);


            }

            foreach (var node in nodes)
            {
                if(node.Value.NumberOfChildren == 1)
                {
                    DFS(node.Value, 0);
                }
            }

            Console.WriteLine(maxSum);

        }

    }
    public class Node
    {
        private int value;
        private bool hasParent;
        private List<Node> children;

        public Node(int value)
        {
            this.value = value;
            this.children = new List<Node>();
        }

        public int NumberOfChildren
        {
            get
            {
                return this.children.Count;
            }
        }

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public void AddChild(Node child)
        {
            child.hasParent = true;
            this.children.Add(child);
        }

        public Node getChildren(int index)
        {
            return this.children[index];
        }
    }
}
