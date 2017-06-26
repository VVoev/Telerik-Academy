using System;
using System.Collections.Generic;

namespace _5.All_Paths_in_Labyrinth
{
    class Program
    {
        static char[,] lab =
   {
        {' ', ' ', ' ', '*', ' ', ' ', ' '},
        {'*', '*', ' ', '*', ' ', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', ' '},
        {' ', '*', '*', '*', '*', '*', ' '},
        {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
    };

        static List<char> path = new List<char>();

        static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }


        static void Main(string[] args)
        {
            FindPathToExit(0, 0, 'X');
        }

        private static void FindPathToExit(int row, int col, char direction)
        {
            PrintLabirinth(row, col);
            if (!InRange(row, col))
            {
                //outsize of labirint
                return;
            }

            //append current direction to path
            path.Add(direction);

            //check for exit
            if(lab[row,col] == 'e')
            {
                PrintPath(path);
            }

            if(lab[row,col] == ' ')
            {
                // Temporary mark the current cell as visited
                lab[row, col] = 'X';

                // Recursively explore all possible directions
                FindPathToExit(row, col - 1, 'L'); // left
                FindPathToExit(row - 1, col, 'U'); // up
                FindPathToExit(row, col + 1, 'R'); // right
                FindPathToExit(row + 1, col, 'D'); // down

                // Mark back the current cell as free
                lab[row, col] = ' ';
            }

            // Remove the last direction from the path
            path.RemoveAt(path.Count - 1);
        }

        private static void PrintLabirinth(int currentRow, int currentCol)
        {
            for (int row = -1; row <= lab.GetLength(0); row++)
            {
                Console.WriteLine();
                for (int col = -1; col <= lab.GetLength(1); col++)
                {
                    if ((row == currentRow) && (col == currentCol))
                    {
                        Console.BackgroundColor = ConsoleColor.Cyan;
                        Console.Write("x");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    else if (!InRange(row, col))
                    {
                        Console.Write(" ");
                    }
                    else if (lab[row, col] == ' ')
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(lab[row, col]);
                    }
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void PrintPath(List<char> path)
        {
            Console.Write("Found path to the exit: ");
            foreach (var dir in path)
            {
                Console.Write(dir);
            }
            Console.WriteLine();
        }
    }
}
