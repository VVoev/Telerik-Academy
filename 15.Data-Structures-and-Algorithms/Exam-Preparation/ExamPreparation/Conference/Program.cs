using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conference
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int count = input[0];
            int pairs = input[1];

            bool[] visited = new bool[count];
            var graph = new Dictionary<int, HashSet<int>>();

            for (int i = 0; i < pairs; i++)
            {
                var pair = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

                if (!graph.ContainsKey(pair[0]))
                {
                    graph[pair[0]] = new HashSet<int>();
                }
                if (!graph.ContainsKey(pair[1]))
                {
                    graph[pair[1]] = new HashSet<int>();
                }

                graph[pair[0]].Add(pair[1]);
                graph[pair[1]].Add(pair[0]);
            }

            var componentsNode = new List<long>();
            foreach (var node in graph.Keys)
            {
                int componentCount = DFS(node, graph, visited);

                if(componentCount != 0)
                {
                    componentsNode.Add(componentCount);
                }
            }


            long singletonsCount = count - graph.Keys.Count;

            long pairsCombinations = 0;
            for (int i = 0; i < componentsNode.Count - 1; i++)
            {
                pairsCombinations += componentsNode[i] * singletonsCount;
                for (int j = i + 1; j < componentsNode.Count; j++)
                {
                    pairsCombinations += componentsNode[i] * componentsNode[j];
                }
            }

            if (singletonsCount > 0)
            {
                if (componentsNode.Count > 0)
                {
                    pairsCombinations += componentsNode[componentsNode.Count - 1] * singletonsCount;
                }

                pairsCombinations += (singletonsCount * (singletonsCount - 1)) / 2;
            }
            Console.WriteLine(pairsCombinations);
        }

        private static int DFS(int node, Dictionary<int, HashSet<int>> graph, bool[] visited)
        {
            int result = 0;
            if (!visited[node])
            {
                visited[node] = true;
                result++;
                if (graph.ContainsKey(node))
                {
                    foreach (var child in graph[node])
                    {
                        if (!visited[child])
                        {
                            result += DFS(child, graph, visited);
                        }
                    }
                }
            }


            return result;
        }
    }
}
