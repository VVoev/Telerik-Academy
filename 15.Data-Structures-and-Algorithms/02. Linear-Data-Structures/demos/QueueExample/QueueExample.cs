namespace QueueExample
{
    using System;
    using System.Collections.Generic;

    public static class QueueExample
    {
        public static void Main()
        {
            var queue = new Queue<string>();

            queue.Enqueue("Message One");
            queue.Enqueue("Message Two");
            queue.Enqueue("Message Three");
            queue.Enqueue("Message Four");
            queue.Enqueue("Message Five");

            while (queue.Count > 0)
            {
                var message = queue.Dequeue();
                Console.WriteLine(message);
            }
        }
    }
}
