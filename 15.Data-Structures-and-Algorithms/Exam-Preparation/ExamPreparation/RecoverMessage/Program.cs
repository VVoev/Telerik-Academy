using System;
using System.Collections;
using System.Collections.Generic;

namespace RecoverMessage
{
    class Program
    {
        static SortedDictionary<char,Node> graph = new SortedDictionary<char, Node>();

        static Node GetNodeByChar(char symbol)
        {
            if (graph.ContainsKey(symbol))
            {
                return graph[symbol];
            }

            var newNode = new Node() { Value = symbol };
            graph.Add(symbol, newNode);
            return newNode;
        }

        static void Main(string[] args)
        {
            int messageNumber = int.Parse(Console.ReadLine());
            var noIncomingEdges = new SortedSet<char>();

            for (int i = 0; i < messageNumber; i++)
            {
                string currentMessage = Console.ReadLine();

                for (int j = 1; j <= currentMessage.Length; j++)
                {
                    Node previousNode = GetNodeByChar(currentMessage[j-1]);
                    Node currentNode = GetNodeByChar(currentMessage[j]);
                    previousNode.Successors.Add(currentNode);
                    currentNode.Parrents.Add(previousNode);

                    previousNode = currentNode;
                }
            }

            foreach (var node in graph.Values)
            {
                if (node.Parrents.Count == 0)
                {
                    noIncomingEdges.Add(node.Value);
                }
            }
            Console.WriteLine();

        }
    }

    class Node
    {
        public Node()
        {
            this.Successors = new HashSet<Node>();
            this.Parrents = new HashSet<Node>();
        }
        public char Value { get; set; }

        public ICollection<Node> Successors { get; set; }

        public ICollection<Node> Parrents { get; set; }
    }
}
