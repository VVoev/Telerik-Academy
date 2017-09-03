using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaPark
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                if (line[0] == "add")
                {
                    queue.Enqueue(int.Parse(line[1]));
                    Console.WriteLine("Added " + line[1]);
                }
                else if (line[0] == "slide")
                {
                    var end = int.Parse(line[1]) % queue.Count;
                    for (int j = 0; j < end; j++)
                    {
                        queue.Enqueue(queue.Dequeue());
                    }

                    Console.WriteLine("Slided " + line[1]);
                }
                else if (line[0] == "print")
                {
                    var result = new List<int>(queue);
                    result.Reverse();

                    Console.WriteLine(string.Join(" ", result));
                }
            }
        }
    }
}
