using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ReverseUsingStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var list =
                Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

            var stack = new Stack<int>();

            list.ForEach(e => stack.Push(e));

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
