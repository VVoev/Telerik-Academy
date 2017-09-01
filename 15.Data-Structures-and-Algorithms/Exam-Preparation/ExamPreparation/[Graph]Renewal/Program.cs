using System;
using System.Collections.Generic;
using System.Linq;

namespace _Graph_Renewal
{
    class Program
    {

        static List<string> roads = new List<string>();
        static List<string> builds = new List<string>();
        static List<string> destroy = new List<string>();
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                roads.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                builds.Add(Console.ReadLine());
            }

            for (int i = 0; i < N; i++)
            {
                destroy.Add(Console.ReadLine());
            }

        }
    }
}
