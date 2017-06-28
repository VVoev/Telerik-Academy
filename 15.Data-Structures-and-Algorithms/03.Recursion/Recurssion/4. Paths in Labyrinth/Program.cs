using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Paths_in_Labyrinth
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

        static List<Tuple<int, int>> path = new List<Tuple<int, int>>();

        public static bool InRange(int row, int col)
        {
            bool rowInRange = row >= 0 && row < lab.GetLength(0);
            bool colInRange = col >= 0 && col < lab.GetLength(1);
            return rowInRange && colInRange;
        }

        public static void FindPathToExit(int row, int col)
        {
            if (!InRange(row, col))
            {
                //out of labirint
                return;
            }

            //check for exit
            if (lab[row, col] == 'e')
            {
                PrintPath(row, col);
            }

            if (lab[row,col] != ' ')
            {
                //the current cell is not free
                return;
            }

            // Temporary mark the current cell as visited to avoid cycles
            lab[row, col] = 's';
            path.Add(new Tuple<int, int>(row, col));

            // Invoke recursion the explore all possible directions
            FindPathToExit(row, col - 1); // left
            FindPathToExit(row - 1, col); // up
            FindPathToExit(row, col + 1); // right
            FindPathToExit(row + 1, col); // down

            // Mark back the current cell as free
            // Comment the below line to visit each cell at most once
            lab[row, col] = ' ';
            path.RemoveAt(path.Count - 1);


        }

        private static void PrintPath(int row, int col)
        {
            Console.Write("Found the exit: ");
            foreach (var cell in path)
            {
                Console.Write("({0},{1}) -> ", cell.Item1, cell.Item2);
            }
            Console.WriteLine("({0},{1})", row, col);
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            // Uncomment the code below to create larger labirinth
            // Test with size = 10 and size = 100

            //int size = 10;
            //lab = new char[size, size];
            //for (int row = 0; row < size; row++)
            //{
            //    for (int col = 0; col < size; col++)
            //    {
            //        lab[row, col] = ' ';
            //    }
            //}
            //lab[size - 1, size - 1] = 'e';
            FindPathToExit(0, 0);
        }

    }
}
