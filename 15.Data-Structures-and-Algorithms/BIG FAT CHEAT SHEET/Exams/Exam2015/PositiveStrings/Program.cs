using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositiveStrings
{
    public class Program
    {
        static string initial;

        public static void Main()
        {
            initial = Console.ReadLine();
            var builder = new StringBuilder(initial);

            Solve(0, builder);

            Console.WriteLine(results.First() ?? "invalid");
        }

        static SortedSet<string> results = new SortedSet<string>();

        public static void Solve(int index, StringBuilder line)
        {
            if (line[0] == ',' || line[line.Length - 1] == ',')
            {
                return;
            }

            if (index > 0 && line[index - 1] == ',')
            {
                return;
            }

            if (index >= line.Length)
            {
                // check is positive
                var lineAsString = line.ToString().Trim();
                if (IsPositive(lineAsString))
                {
                    results.Add(lineAsString);
                }

                return;
            }

            if (line[index] != '?')
            {
                Solve(index + 1, line);
            }
            else
            {
                line[index] = ',';
                Solve(index + 1, line);

                for (int i = '0'; i <= '9'; i++)
                {
                    line[index] = (char)i;
                    Solve(index + 1, line);
                }

                line[index] = initial[index];
            }
        }

        public static bool IsPositive(string list)
        {
            var arr = list.Split(',').Select(long.Parse).ToArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
