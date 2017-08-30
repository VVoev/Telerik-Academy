using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _graph_PenguinAirlines
{
    class Program
    {
        public static Dictionary<int, List<int>> graph = new Dictionary<int, List<int>>();
        public static StringBuilder sb = new StringBuilder();
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            FillingTheGraph(N);

            var command = Console.ReadLine();
            while (command != "Have a break")
            {
                var commandInfo = command.Split(' ');
                var from = int.Parse(commandInfo[0]);
                var to = int.Parse(commandInfo[1]);
                if (graph[from].Contains(to))
                {
                    sb.AppendLine("There is a direct flight.");
                }
                else
                {
                    var visited = new bool[N];
                    DFS(from, graph, visited);
                    sb = visited[to] == true ? 
                    sb.AppendLine("There are flights, unfortunately they are not direct, grandma :("):
                    sb.AppendLine("No flights available.");
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(sb.ToString());
        }

        private static void DFS(int x, Dictionary<int, List<int>> graph,bool[] visited)
        {
            visited[x] = true;
            foreach (var y in graph[x])
            {
                if (!visited[y])
                {
                    DFS(y, graph, visited);
                }
            }
        }
        private static void FillingTheGraph(int N)
        {
            for (int i = 0; i < N; i++)
            {
                if (!graph.ContainsKey(i))
                {
                    graph[i] = new List<int>();
                }
                var lines = Console.ReadLine().Split(' ');
                if (lines[0] == "None")
                {
                    continue;
                }
                foreach (var line in lines)
                {
                    var island = int.Parse(line);
                    graph[i].Add(island);
                }
            }
        }
    }
}
