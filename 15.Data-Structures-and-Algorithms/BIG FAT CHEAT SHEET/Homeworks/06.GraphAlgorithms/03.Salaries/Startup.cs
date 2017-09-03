using System;
using System.Collections.Generic;

namespace Salaries.Task
{
    public class Startup
    {
        public static void Main()
        {
            int employeesCount = int.Parse(Console.ReadLine());
            Node[] nodes = new Node[employeesCount];
            long[] memoSalaries = new long[nodes.Length];

            for (int i = 0; i < employeesCount; i++)
            {
                var line = Console.ReadLine();
                if (nodes[i] == null)
                {
                    nodes[i] = new Node(i);
                }

                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == 'Y')
                    {
                        if (nodes[j] == null)
                        {
                            nodes[j] = new Node(j);
                        }

                        nodes[i].Children.Add(nodes[j]);
                    }
                }
            }

            long salaries = 0;
            foreach (var node in nodes)
            {
                salaries += FindSalary(node, memoSalaries);
            }

            Console.WriteLine(salaries);
        }

        public static long FindSalary(Node node, long[] memoSalaries)
        {
            if (memoSalaries[node.Index] != 0)
            {
                return memoSalaries[node.Index];
            }

            if (node.Children.Count == 0)
            {
                return 1;
            }

            long salary = 0;
            foreach (var child in node.Children)
            {
                salary += FindSalary(child, memoSalaries);
            }

            memoSalaries[node.Index] = salary;
            return salary;
        }
    }

    public class Node
    {
        public Node(int index)
        {
            this.Children = new List<Node>();
            this.Index = index;
        }

        public int Index { get; set; }

        public List<Node> Children { get; set; }
    }
}