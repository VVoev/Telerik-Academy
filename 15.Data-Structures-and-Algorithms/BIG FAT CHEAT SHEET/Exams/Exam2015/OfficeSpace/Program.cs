using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace GraphsAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var minutes = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var dependencies = new List<int>[n + 1];

            for (int  i = 1; i < dependencies.Length; i++)
            {
                dependencies[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            }

            var memo = new int[n + 1];
            var answers = new int[n + 1];
            for (int i = 1; i < dependencies.Length; i++)
            {
                answers[i] = FindMinTime(i, dependencies, minutes, memo, 0);
                // Console.WriteLine($"{i} => {answers[i]}");
            }

            Console.WriteLine(answers.Skip(1).Max());
        }

        public static int FindMinTime(int node, List<int>[] graph, int[] minutes, int[] memo, int stepsCount)
        {
            // high quality code :)
            if (stepsCount > graph.Length)
            {
                Console.WriteLine(-1);
                Environment.Exit(0);
            }

            if (graph[node].Count == 1 && graph[node][0] == 0)
            {
                return minutes[node - 1];
            }

            if (memo[node] != 0)
            {
                return memo[node];
            }

            var maxTime = 0;
            foreach (var dependencyNode in graph[node])
            {
                var dependencyTime = FindMinTime(dependencyNode, graph, minutes, memo, stepsCount + 1);
                maxTime = Math.Max(dependencyTime, maxTime);
            }

            memo[node] = maxTime + minutes[node - 1];
            return memo[node];
        }
    }
}