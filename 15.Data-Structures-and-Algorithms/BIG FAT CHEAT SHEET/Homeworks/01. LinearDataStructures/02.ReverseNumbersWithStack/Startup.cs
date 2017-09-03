using System;
using System.Collections.Generic;

namespace _02.ReverseNumbersWithStack
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int numberToAdd = int.Parse(Console.ReadLine());
                stack.Push(numberToAdd);
            }

            int stackLenght = stack.Count;
            for (int i = 0; i < stackLenght; i++)
            {
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
