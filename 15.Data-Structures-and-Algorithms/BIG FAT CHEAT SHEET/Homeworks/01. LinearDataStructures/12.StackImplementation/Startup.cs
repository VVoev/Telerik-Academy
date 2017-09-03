using System;

namespace _12.StackImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var stack = new System.Collections.Generic.Stack<int>();
            var myStack = new Stack<int>();

            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
                myStack.Push(i);
            }

            for (int i = 0; i < 3; i++)
            {
                stack.Pop();
                myStack.Pop();
            }

            Console.WriteLine(stack.Peek());
            Console.WriteLine(myStack.Peek());

            Console.WriteLine(string.Join(", ", stack));
            Console.WriteLine(string.Join(", ", myStack));
        }
    }
}
