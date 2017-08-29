using System;
using System.Collections.Generic;
using System.Linq;

namespace mineGraph
{
    public class Distance
    {
        static Dictionary<string,List<Node>> graph = new Dictionary<string, List<Node>>();
        static HashSet<string> Visited = new HashSet<string>();
        public static void Calculate()
        {

            /*
            sofiq plovdiv 120
            starazagora sofiq 225
            sofiq pleven 192
            sofiq burgas 380
            sofiq pazardjik 83
            ruse varna 240
            varna burgas 101
            gabrovo sofiq 240
            kazanluk starazagora 35
            plovdiv gabrovo 142
            */
            for (int i = 0; i < 10; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var town = input[0];
                var toTown = input[1];
                var distance = int.Parse(input[2]);
                if (!graph.ContainsKey(town))
                {
                    graph[town] = new List<Node>();
                }
                var node = new Node(toTown, distance);
                graph[town].Add(node);
            }

            foreach (var node in graph)
            {
                    usedNodes.Clear();
                    DFS(node.Key);
            }
            //Print();
        }

        private static void Print()
        {
            foreach (var item in graph)
            {
                Console.Write(item.Key + "=>");
                foreach (var x in item.Value)
                {
                    Console.Write($"{x.Name} with distance {x.Distance}");
                }
                Console.WriteLine();
            }
        }

        static List<Node> usedNodes = new List<Node>();
        private static void DFS(string node)
        {
            for (int i = 0; i < graph[node].Count; i++)
            {
                var currentNode = graph[node][i];
                usedNodes.Add(currentNode);

                if (usedNodes.Contains(graph[node][i]))
                {
                    continue;
                }
                DFS(graph[node][i].Name);       
                
            }
        }
    }

    class Node
    {
        public string Name { get; set; }

        public int Distance { get; set; }


        public Node(string name,int distance)
        {
            this.Name = name;
            this.Distance = distance;
        }
    }
}
