using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFullOfBalls
{
    public class Program
    {
        public static void Main()
        {
            var moves = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            var range = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int start = range[0];
            int end = range[1];

            var games = new bool[end + 1];
            games[0] = true;
            // fill up winning games
            foreach (var move in moves)
            {
                games[move] = true;
            }

            for (int i = 0; i <= end; i++)
            {
                if (games[i])
                {
                    continue;
                }

                foreach (var move in moves)
                {
                    if (i - move >= 0 && games[i - move] == false)
                    {
                        games[i] = true;
                        break;
                    }
                }
            }

            var result = 0;
            for (int i = start; i <= end; i++)
            {
                result += games[i] ? 1 : 0;
            }

            Console.WriteLine(result);
        }
    }
}
