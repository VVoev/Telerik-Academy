using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _02.Swapping
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var swaps = Console.ReadLine().Split(' ').Select(int.Parse);

            var nodes = new LinkedNode[n + 1];
            nodes[0] = new LinkedNode(-20);
            nodes[1] = new LinkedNode(1);
            for (int i = 2; i < nodes.Length; i++)
            {
                var currentNode = new LinkedNode(i);
                nodes[i - 1].Attach(currentNode);
                nodes[i] = currentNode;
            }

            var first = nodes[1];
            var last = nodes[nodes.Length - 1];

            foreach (var swap in swaps)
            {
                var targetNode = nodes[swap];

                var newFirst = targetNode.Right;
                var newLast = targetNode.Left;

                targetNode.Detach();

                if (first == targetNode)
                {
                    last.Attach(targetNode);
                    first = newFirst;
                    last = targetNode;
                }
                else if (last == targetNode)
                {
                    targetNode.Attach(first);
                    last = newLast;
                    first = targetNode;
                }
                else
                {
                    targetNode.Attach(first);
                    last.Attach(targetNode);

                    first = newFirst;
                    last = newLast;
                }
            }

            Console.WriteLine(string.Join(" ", first));
        }
    }

    public class LinkedNode : IEnumerable<int>
    {
        public int Value { get; private set; }

        public LinkedNode Left { get; private set; }

        public LinkedNode Right { get; private set; }

        public LinkedNode(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public void Detach()
        {
            if (this.Left != null)
            {
                this.Left.Right = null;
                this.Left = null;
            }

            if (this.Right != null)
            {
                this.Right.Left = null;
                this.Right = null;
            }
        }

        public void Attach(LinkedNode node)
        {
            this.Right = node;
            node.Left = this;
        }

        public IEnumerator<int> GetEnumerator()
        {
            var node = this;
            while (node != null)
            {
                yield return node.Value;
                node = node.Right;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
