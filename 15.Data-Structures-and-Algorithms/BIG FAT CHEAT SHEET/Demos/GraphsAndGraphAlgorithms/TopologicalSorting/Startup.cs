using System;
using System.Collections.Generic;
using System.Linq;

namespace TopologicalSorting
{
    public class Startup
    {
        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            var sorted = TopologicalSort(nodesCount);
            Console.WriteLine(string.Join(", ", sorted));
        }

        public static List<int> TopologicalSort(int nodesCount)
        {
            var graph = new LinkedList<int>[nodesCount + 1];
            var dependecies = new int[nodesCount + 1];

            while (true)
            {
                var line = Console.ReadLine();
                if (line == string.Empty)
                {
                    break;
                }

                var connectionParts = line
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray();
                int from = connectionParts[0];
                int to = connectionParts[1];

                if (graph[from] == null)
                {
                    graph[from] = new LinkedList<int>();
                }
                if (graph[to] == null)
                {
                    graph[to] = new LinkedList<int>();
                }

                graph[from].AddLast(to);
                dependecies[to]++;
            }

            var queue = new Queue<int>();
            for (int i = 1; i < dependecies.Length; i++)
            {
                if (dependecies[i] == 0)
                {
                    queue.Enqueue(i);
                }
            }

            Console.WriteLine(string.Join(", ", dependecies));
            var result = new List<int>();

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                result.Add(currentNode);
                foreach (var successor in graph[currentNode])
                {
                    dependecies[successor]--;
                    if (dependecies[successor] == 0)
                    {
                        queue.Enqueue(successor);
                    }
                }
            }

            return result;
        }
    }
}
