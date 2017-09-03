using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Swapping
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var swaps = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var nodes = new ListNode[n + 1];
            for (int i = 1; i < nodes.Length - 1; i++)
            {
                if (nodes[i] == null)
                {
                    nodes[i] = new ListNode();
                    nodes[i].Value = i;
                }

                if (nodes[i + 1] == null)
                {
                    nodes[i + 1] = new ListNode();
                    nodes[i + 1].Value = i + 1;
                }

                nodes[i].Next = nodes[i + 1];
                nodes[i + 1].Prev = nodes[i];
            }

            var first = nodes[1];
            var last = nodes[nodes.Length - 1];

            foreach (var swapIndex in swaps)
            {
                var nodeToSwap = nodes[swapIndex];

                if (first.Value == nodeToSwap.Value)
                {
                    if (first.Next != null)
                    {
                        first = first.Next;
                        first.Prev = null;

                        last.Next = nodeToSwap;
                        nodeToSwap.Prev = last;
                        last = nodeToSwap;
                    }
                }
                else if (nodeToSwap.Value == last.Value)
                {
                    if (last.Prev != null)
                    {
                        last = last.Prev;
                        last.Next = null;

                        first.Prev = nodeToSwap;
                        nodeToSwap.Next = first;
                        first = nodeToSwap;
                    }
                }
                else
                {
                    var next = nodeToSwap.Next;
                    var prev = nodeToSwap.Prev;

                    nodeToSwap.Next = first;
                    nodeToSwap.Prev = last;

                    first.Prev = nodeToSwap;
                    last.Next = nodeToSwap;

                    first = next;
                    last = prev;

                    first.Prev = null;
                    last.Next = null;
                }

            }

            var result = new List<int>();

            var node = first;
            while (node != null)
            {
                result.Add(node.Value);
                node = node.Next;
            }

            Console.WriteLine(string.Join(" ", result));
        }
    }

    public class ListNode
    {
        public int Value { get; set; }

        public ListNode Next { get; set; }

        public ListNode Prev { get; set; }
    }
}
