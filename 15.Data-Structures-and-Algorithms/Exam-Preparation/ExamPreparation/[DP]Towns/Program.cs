using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DP_Towns
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = int.Parse(Console.ReadLine());
            var towns = new List<int>();
            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(' ');
                var population = int.Parse(input[0]);
                towns.Add(population);
            }

            var bestPath = LIDS(towns);

            Console.WriteLine(bestPath);
        }

        private static int LIDS(List<int> citizens)
        {
            int numberOftowns = citizens.Count;

            //Find LIS first
            var longestPathAscending = new int[numberOftowns];

            for (int currentTown = 0; currentTown < numberOftowns; currentTown++)
            {
                longestPathAscending[currentTown] = 1;
                for (int previousTown = 0; previousTown < currentTown; previousTown++)
                {
                    if(citizens[previousTown] < citizens[currentTown])
                    {
                        longestPathAscending[currentTown] = Math.Max(longestPathAscending[currentTown], longestPathAscending[previousTown]+1);
                    }
                }
            }

            // Second, find the longest paths in descending order
            var longestPathDescending = new int[numberOftowns];
            for (int currentTown = numberOftowns - 1; currentTown >= 0; currentTown--)
            {
                longestPathDescending[currentTown] = 1;
                for (int previousTown = numberOftowns - 1; previousTown > currentTown; previousTown--)
                {
                    if (citizens[previousTown] < citizens[currentTown])
                    {
                        longestPathDescending[currentTown] = Math.Max(longestPathDescending[currentTown], longestPathDescending[previousTown] + 1);
                    }
                }
            }

            // Third, combine paths by choosing best town to be the separator
            var bestPath = 0;
            for (int currentTown = 0; currentTown < numberOftowns; currentTown++)
            {
                var currentPath = longestPathAscending[currentTown] + longestPathDescending[currentTown] - 1;
                bestPath = Math.Max(bestPath, currentPath);
            }
            Console.WriteLine();
            return bestPath;
        }
    }
}
