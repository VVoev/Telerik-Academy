using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HungryTom
{
    public class Program
    {
        static LinkedList<int>[] graph;

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            graph = ReadGraph(nodesCount, edgesCount);

            var visited = new bool[nodesCount + 1];
            Solve(1, 0, new List<int>(), visited);

            if (results.Count == 0)
            {
                Console.WriteLine(-1);
                return;
            }

            Console.WriteLine(results.Count);
            Console.WriteLine(string.Join("\n", results));
        }

        static SortedSet<Collection> results = new SortedSet<Collection>();

        public static void Solve(int node, int visitedCount, List<int> currentResult, bool[] visited)
        {
            if (visited[node])
            {
                return;
            }

            visitedCount++;
            currentResult.Add(node);

            if (visitedCount == graph.Length - 1 && graph[node].Contains(1))
            {
                currentResult.Add(1);
                results.Add(new Collection(currentResult));
                currentResult.RemoveAt(currentResult.Count - 1);
                currentResult.RemoveAt(currentResult.Count - 1);
                return;
            }

            visited[node] = true;
            foreach (var child in graph[node])
            {
                Solve(child, visitedCount, currentResult, visited);
            }

            currentResult.RemoveAt(currentResult.Count - 1);

            visited[node] = false;
        }

        public static LinkedList<int>[] ReadGraph(int nodesCount, int edgesCount)
        {
            var graph = new LinkedList<int>[nodesCount + 1].Select(x => new LinkedList<int>()).ToArray();

            for (int i = 0; i < edgesCount; i++)
            {
                var line = Console.ReadLine().Split(' ');
                int from = int.Parse(line[0]);
                int to = int.Parse(line[1]);

                AddConnection(graph, from, to);
                AddConnection(graph, to, from);
            }

            return graph;
        }

        public static void AddConnection(LinkedList<int>[] graph, int from, int to)
        {
            if (graph[from] == null)
            {
                graph[from] = new LinkedList<int>();
            }

            graph[from].AddLast(to);
        }

        public class Collection : IComparable<Collection>
        {
            public Collection(List<int> numbers)
            {
                this.Numbers = new List<int>(numbers);
            }

            public List<int> Numbers { get; set; }

            public int CompareTo(Collection other)
            {
                for (int i = 0; i < this.Numbers.Count; i++)
                {
                    if (Numbers[i] < other.Numbers[i])
                    {
                        return -1;
                    }
                    else if (Numbers[i] > other.Numbers[i])
                    {
                        return 1;
                    }
                }

                return 0;
            }

            public override string ToString()
            {
                return string.Join(" ", this.Numbers);
            }
        }
    }
}
