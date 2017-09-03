using System;
using System.Collections.Generic;

namespace QueueImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var queue = new Queue<int>();
            var myQueue = new LinkedQueue<int>();

            for (int i =0; i < 20; i++)
            {
                queue.Enqueue(i);
                myQueue.Enqueue(i);
            }

            for (int i =0; i < 10; i++)
            {
                queue.Dequeue();
                myQueue.Dequeue();
            }

            Console.WriteLine(queue.Peek());
            Console.WriteLine(myQueue.Peek());

            Console.WriteLine(string.Join(", ", queue));
            Console.WriteLine(string.Join(", ", myQueue));
        }
    }
}
