namespace Sequence
{
    using System;
    using System.Collections.Generic;

    public static class QueueExample
    {
        public static void Main()
        {
            var n = 3;
            var p = 16;

            var queue = new Queue<int>();
            queue.Enqueue(n);

            Console.WriteLine("N = {0}", n);
            Console.WriteLine("P = {0}", p);
            Console.Write("S =");

            var index = 0;
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                Console.Write(" {0}", current);
                index++;

                if (current == p)
                {
                    Console.WriteLine();
                    Console.WriteLine("Index = {0} (starting from 1)", index);
                    return;
                }

                queue.Enqueue(current + 1);
                queue.Enqueue(2 * current);
            }
        }
    }
}
