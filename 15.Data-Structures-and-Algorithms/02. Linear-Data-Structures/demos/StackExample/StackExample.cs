namespace StackExample
{
    using System;
    using System.Collections.Generic;

    public static class StackExample
    {
        public static void Main()
        {
            var stack = new Stack<string>();

            stack.Push("1. Viktor");
            stack.Push("2. Marto");
            stack.Push("3. Doncho");
            stack.Push("4. Cuki");
            stack.Push("5. Evlogi");
            stack.Push("6. Konstantin");
            stack.Push("7. Ivan");
            stack.Push("8. Steven");

            Console.WriteLine("Top = {0}", stack.Peek());
            while (stack.Count > 0)
            {
                var personName = stack.Pop();
                Console.WriteLine(personName);
            }
        }
    }
}