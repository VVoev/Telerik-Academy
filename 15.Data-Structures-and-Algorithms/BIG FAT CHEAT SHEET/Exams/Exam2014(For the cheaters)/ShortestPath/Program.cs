using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPath
{
    public class Program
    {
        static StringBuilder results = new StringBuilder();
        static int resultsCount = 0;

        public static void Main()
        {
            var line = Console.ReadLine().ToCharArray();
            Solve(0, line);
            Console.WriteLine(resultsCount);
            Console.WriteLine(results.ToString().Trim());
        }

        static char[] letters = new char[] { 'L', 'R', 'S' };

        public static void Solve(int index, char[] current)
        {
            if (index >= current.Length)
            {
                results.AppendLine(string.Join("", current));
                resultsCount++;
                return;
            }

            if (current[index] != '*')
            {
                Solve(index + 1, current);
            }
            else
            {
                for (int i = 0; i < letters.Length; i++)
                {
                    current[index] = letters[i];
                    Solve(index + 1, current);
                    current[index] = '*';
                }
            }
        }
    }
}
