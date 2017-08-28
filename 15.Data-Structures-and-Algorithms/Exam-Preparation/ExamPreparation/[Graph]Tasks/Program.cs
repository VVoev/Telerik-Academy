using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Graph_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var time = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var adjancyMatrix = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                var requirements = Console.ReadLine().Split(' ').Select(int.Parse);
                if(requirements.First() != 0)
                {
                    foreach (var requirement in requirements)
                    {
                        adjancyMatrix[requirement - 1, i] = true;
                    }
                }
            }
            Console.WriteLine();
        }
    }
}
