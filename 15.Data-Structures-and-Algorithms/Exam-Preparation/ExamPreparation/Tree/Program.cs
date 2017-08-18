using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    class Program
    {
        static int N;
        static Node<int>[] nodes;

        public static int FindRoot(Node<int>[] nodes)
        {
            var isChild = new bool[nodes.Length];

            foreach (var node in nodes)
            {
                foreach (var child in node.Children)
                {
                    isChild[child.Value] = true;
                }
            }

            for (int i = 0; i < isChild.Length; i++)
            {
                if (!isChild[i])
                {
                    return i;
                }
            }

            return int.MinValue;
        }

        static void Main(string[] args)
        {

            /*
                7
                2 4
                3 2
                5 0
                3 5
                5 6
                5 1  
                     */
            N = int.Parse(Console.ReadLine());
            nodes = new Node<int>[N];

            for (int i = 0; i < N; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < N - 1; i++)
            {
                string edgeAsString = Console.ReadLine();
                string[] edgeParts = edgeAsString.Split(' ').ToArray();

                int parentId = int.Parse(edgeParts[0]);
                int childId = int.Parse(edgeParts[1]);

                nodes[parentId].Children.Add(nodes[childId]);
                nodes[childId].HasParent = true;
            }

            //Print(nodes);

            //1 Find roots
            var root = FindRoot(nodes);
            Console.WriteLine($"Root is {root}");

            //2 Find all leafes
            var leaves = FindLeafes(nodes);
            Console.Write("Leafes are: ");
            foreach (var leaf in leaves)
            {
                Console.Write(leaf.Value + " ");
            }
            Console.WriteLine();

            //3 Find all mid nodes
            var midNodes = FindAllMidNodes();
            Console.Write("Mid nodes are: ");
            foreach (var midN in midNodes)
            {
                Console.Write(midN.Value + " ");
            }
            Console.WriteLine();
        }

        private static List<Node<int>> FindAllMidNodes()
        {
            var midNodes = new List<Node<int>>();
            foreach (var node in nodes)
            {
                if (node.HasParent && node.Children.Count > 0)
                {
                    midNodes.Add(node);
                }
            }

            return midNodes;
        }

        private static List<Node<int>>FindLeafes(Node<int>[] nodes)
        {

            List<Node<int>> leaves = new List<Node<int>>();
            foreach (var node in nodes)
            {
                if(node.Children.Count == 0)
                {
                    leaves.Add(node);
                }
            }

            return leaves;
        }

        private static void Print(Node<int>[] nodes)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(node);
            }
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }

        public List<Node<T>> Children { get; set; }

        public bool HasParent { get; set; }

        public Node()
        {
            this.Children = new List<Node<T>>();
        }

        public Node(T value)
            :this()
        {
            this.HasParent = false;
            this.Value = value;
        }

        public override string ToString()
        {
            return $"{this.Value} with children {string.Join(" ",this.Children)}";
        }
    }
}
