using System;
using System.Collections.Generic;

namespace _09.FindFirst50OfSequence
{
    public class Startup
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();
            queue.Enqueue(n);

            for (int i =0; i < 50; i++)
            {
                var currentNumber = queue.Dequeue();
                queue.Enqueue(currentNumber + 1);
                queue.Enqueue(currentNumber * 2 + 1);
                queue.Enqueue(currentNumber + 2);

                Console.WriteLine(currentNumber);
            }
        }
    }
}
