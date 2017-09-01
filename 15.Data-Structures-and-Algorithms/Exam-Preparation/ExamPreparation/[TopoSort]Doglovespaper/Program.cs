using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class Node
    {
        public int Predecessors = 0;
        public List<char> Successors = new List<char>();
    }

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var graph = new Dictionary<char, Node>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(' ');
                char x = line[0].ToCharArray()[0];
                char y = line[3].ToCharArray()[0];

                if (!graph.ContainsKey(x))
                {
                    graph.Add(x, new Node());
                }
                if (!graph.ContainsKey(y))
                {
                    graph.Add(y, new Node());
                }

                if (line[2] == "after")
                {
                    graph[x].Predecessors++;
                    graph[y].Successors.Add(x);
                }
                else
                {
                    graph[y].Predecessors++;
                    graph[x].Successors.Add(y);
                }
            }

            TS(graph);
        }

        static void TS(Dictionary<char, Node> graph)
        {
            var result = new List<char>();

            var noIncoming = new SortedDictionary<char, Node>();

            foreach (var node in graph)
            {
                if (node.Value.Predecessors == 0)
                {
                    noIncoming.Add(node.Key, node.Value);
                }
            }

            while (noIncoming.Count != 0)
            {
                var tmp = noIncoming.First();

                var current = noIncoming.First();
                noIncoming.Remove(current.Key);

                if (current.Key == '0' && result.Count == 0)
                {
                    current = noIncoming.First();
                    noIncoming.Remove(current.Key);
                    noIncoming.Add(tmp.Key, tmp.Value);
                }

                result.Add(current.Key);

                foreach (var node in current.Value.Successors)
                {
                    graph[node].Predecessors--;
                    if (graph[node].Predecessors == 0)
                    {
                        noIncoming.Add(node, graph[node]);
                    }
                }
            }

            Console.WriteLine(string.Join("", result));
        }
    }
}