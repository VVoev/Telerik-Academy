using System;
using System.Collections.Generic;

namespace _Graph_MaximalPath
{
    class Program
    {
        static int maxSum = 0;
        static List<Node> usednodes = new List<Node>();
        static void DFS(Node node,int currentSum)
        {
            currentSum += node.Value;
            usednodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usednodes.Contains(node.GetChild(i)))
                {
                    continue;
                }
                DFS(node.GetChild(i),currentSum);
            }

            if(node.NumberOfChildren == 1 && currentSum>maxSum)
            {
                maxSum = currentSum;
            }
        }
        static void Main(string[] args)
        {
            //AuthorSolution.Solution();
            int N = int.Parse(Console.ReadLine());
            var nodes = new Dictionary<int, Node>();

            for (int i = 0; i < N-1; i++)
            {
                var input = Console.ReadLine().Split(new char[] { '(', ')', '-', '<' }, StringSplitOptions.RemoveEmptyEntries);
                int parent = int.Parse(input[0]);
                int child = int.Parse(input[1]);

                Node childNode;
                Node parrentNode; 

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

                parrentNode.addChild(childNode);
                childNode.addChild(parrentNode);
            }
            foreach (var node in nodes)
            {
                if(node.Value.NumberOfChildren == 1)
                {
                    usednodes.Clear();
                    DFS(node.Value,0);
                }
            }
            Console.WriteLine(maxSum);


        }
    }
    class Node
    {
        private int value;
        private List<Node> children;
        private bool hasParent;

        public int Value
        {
            get
            {
                return this.value;
            }
        }

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

        public void addChild(Node child)
        {
            this.hasParent = true;
            this.children.Add(child);
        }

        public Node GetChild(int index)
        {
            return this.children[index];
        }
    }
}
