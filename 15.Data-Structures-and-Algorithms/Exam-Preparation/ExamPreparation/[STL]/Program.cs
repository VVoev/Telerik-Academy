using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _STL_
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var q = new Queue<int>();
            var sb = new StringBuilder();

            for (int i = 0; i < N; i++)
            {
                var line = Console.ReadLine().Split(' ').ToArray();
                var command = line[0];
                switch (command)
                {
                    case "add":
                        var number = int.Parse(line[1]);
                        q.Enqueue(number);
                        Console.WriteLine(("Added {0}"), number);
                        break;
                    case "print":
                        var newQ = new Queue<int>(q);
                        var list = new List<int>();
                        while (newQ.Count > 0)
                        {
                            var elem = newQ.Dequeue();
                            list.Add(elem);
                        }
                        list.Reverse();
                        Console.WriteLine(string.Join(" ",list));
                        
                        break;
                    case "slide":
                        var howMuch = int.Parse(line[1]);
                        for (int j = 0; j < howMuch; j++)
                        {
                            var elem = q.Dequeue();
                            q.Enqueue(elem);
                        }
                        Console.WriteLine("Slided {0}",howMuch);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
