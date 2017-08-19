using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bb
{
    class Program
    {
        static Node FindRoot()
        {
            var c = nodes.FirstOrDefault((x => x.Value.HasParent == false));
            return c.Value;
        }
        static void DFS(Node node,int currentSum)
        {
            currentSum += node.Value;
            usedNodes.Add(node);

            for (int i = 0; i < node.NumberOfChildren; i++)
            {
                if (usedNodes.Contains(node.GetChild(i)))
                {
                    continue;
                }
                DFS(node.GetChild(i),currentSum);
            }

            if(node.NumberOfChildren == 1 && currentSum > maxSum)
            {
                maxSum = Math.Max(maxSum, currentSum);
            }
        }
        static int N;
        static int maxSum = 0;
        static HashSet<Node> usedNodes = new HashSet<Node>();
        static Dictionary<int, Node> nodes;
        static void Main(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            nodes = new Dictionary<int, Node>();
            int maxNode = 0;

            for (int i = 0; i < N-1; i++)
            {
                string input = Console.ReadLine();
                var separateInput = input.Split(new char[] { '-', '(', ')', ' ','<' },StringSplitOptions.RemoveEmptyEntries);
                var parent = int.Parse(separateInput[0]);
                var child = int.Parse(separateInput[1]);

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


                if (parent > maxNode)
                {
                    maxNode = parent;
                }
                if(child> maxNode)
                {
                    maxNode = child;
                }

                parrentNode.AddChild(childNode);
                childNode.AddChild(parrentNode);
            }
            //DFS(nodes[maxNode],0);
            foreach (var node in nodes)
            {
                if (node.Value.NumberOfChildren == 1)
                {
                    usedNodes.Clear();
                    DFS(node.Value, 0);
                }

            }
            Console.WriteLine(maxSum);
        }
    }
    class Node
    {
        private List<Node> children;
        private bool hasParent;
        private int value;
        public Node(int value)
        {
            this.value = value;
            this.children = new List<Node>();
        }

        public int Value
        {
            get
            {
                return this.value;
            }
        }

        public bool HasParent
        {
            get
            {
                return this.hasParent;
            }
        }

        public void AddChild(Node child)
        {
            child.hasParent = true;
            children.Add(child);
        }

        public void AddParent(Node parrent)
        {
            children.Add(parrent);
        }

        public int NumberOfChildren
        {
            get
            {
                return this.children.Count;
            }
        }
        public Node GetChild(int index)
        {
            return this.children[index];
        }
    }
}
