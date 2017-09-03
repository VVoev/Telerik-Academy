using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Guards
{
    public class Program
    {
        public static void Main()
        {
            var directions = new Dictionary<string, int>();
            directions.Add("R", -1);
            directions.Add("D", -2);
            directions.Add("L", -3);
            directions.Add("U", -4);

            var line = Console.ReadLine().Split(' ');
            int rows = int.Parse(line[0]);
            int cols = int.Parse(line[1]);

            var visited = new bool[rows, cols];
            var maze = new long[rows, cols];

            int guardsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < guardsCount; i++)
            {
                line = Console.ReadLine().Split(' ');
                int row = int.Parse(line[0]);
                int col = int.Parse(line[1]);

                maze[row, col] = directions[line[2]];
            }

            maze[0, 0] = 1;
            visited[0, 0] = true;
            maze[rows - 1, cols - 1] = long.MaxValue;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (row == 0 && col == 0)
                    {
                        continue;
                    }

                    if (maze[row, col] < 0)
                    {
                        continue;
                    }

                    long left = col - 1 >= 0 ? maze[row, col - 1] : 0;
                    long up = row - 1 >= 0 ? maze[row - 1, col] : 0;

                    if (left <= 0 && up <= 0)
                    {
                        continue;
                    }

                    int toAdd = isGuardNear(row, col, maze) ? 3 : 1;
                    if (left > 0 && up > 0)
                    {
                        maze[row, col] = Math.Min(left, up) + toAdd;
                    }
                    else if (left > 0)
                    {
                        maze[row, col] = left + toAdd;
                    }
                    else
                    {
                        maze[row, col] = up + toAdd;
                    }
                }
            }

            if (maze[rows - 1, cols - 1] == long.MaxValue)
            {
                Console.WriteLine("Meow");
            }
            else
            {
                Console.WriteLine(maze[rows - 1, cols - 1]);
            }
        }

        public static bool isGuardNear(int row, int col, long[,] maze)
        {
            // Guard Position

            // Right
            if (col + 1 < maze.GetLength(1) && maze[row, col + 1] == -3)
            {
                return true;
            }

            // Down
            if (row + 1 < maze.GetLength(0) && maze[row + 1, col] == -4)
            {
                return true;
            }

            // Left
            if (col - 1 >= 0 && maze[row, col - 1] == -1)
            {
                return true;
            }

            // Up
            if (row - 1 >= 0 && maze[row - 1, col] == -2)
            {
                return true;
            }

            return false;
        }
    }
}
