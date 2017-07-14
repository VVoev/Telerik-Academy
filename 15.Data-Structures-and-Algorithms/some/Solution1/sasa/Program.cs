namespace Sasa
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var adjList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();
                if (line == "None")
                {
                    adjList[i] = new List<int>();
                }
                else
                {
                    adjList[i] = line.Split(' ').Select(int.Parse).ToList();
                }

            }

            while (true)
            {
                var line = Console.ReadLine();
                if (line == "Have a break")
                {
                    break;
                }

                var strs = line.Split(' ');
                var a = int.Parse(strs[0]);
                var b = int.Parse(strs[1]);

                if (adjList[a].Contains(b))
                {
                    Console.WriteLine("There is a direct flight.");
                }

                else
                {
                    var visited = new bool[n];
                    DFS(a, adjList, visited);

                    if (visited[b])
                    {
                        Console.WriteLine("There are flights, unfortunately they are not direct, grandma :(");
                    }

                    else
                    {
                        Console.WriteLine("No flights available.");
                    }
                }
            }
        }

        static void DFS(int x, List<int>[] adjList, bool[] isVisited)
        {
            isVisited[x] = true;
            foreach (var y in adjList[x])
            {
                if (!isVisited[y])
                {
                    DFS(y, adjList, isVisited);
                }
            }
        }
    }
}
