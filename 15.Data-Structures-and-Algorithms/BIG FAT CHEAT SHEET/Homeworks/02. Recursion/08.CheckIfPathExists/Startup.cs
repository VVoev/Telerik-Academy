using System;

namespace _08.CheckIfPathExists
{
    public class Startup
    {
        private static char[,] lab =
        {
            {' ', ' ', 'x', 'x', ' ', ' ', ' '},
            {'x', ' ', 'x', 'x', ' ', 'x', ' '},
            {'x', ' ', 'x', 'x', ' ', 'x', ' '},
            {'x', ' ', 'x', 'x', ' ', 'x', ' '},
            {'x', ' ', ' ', ' ', 'x', 'x', 'e'},
        };

        private static bool pathExists = false;

        public static void Main()
        {
            PathExists(0, 0);
            Console.WriteLine(pathExists);
        }

        public static void PathExists(int rowIndex, int colIndex)
        {
            if (!CanPassThroughCell(rowIndex, colIndex) || pathExists)
            {
                return; 
            }

            if (lab[rowIndex, colIndex] == 'e')
            {
                pathExists = true;
                return;
            }

            lab[rowIndex, colIndex] = '-';

            PathExists(rowIndex, colIndex + 1);
            PathExists(rowIndex + 1, colIndex);
            PathExists(rowIndex, colIndex - 1);
            PathExists(rowIndex - 1, colIndex);

            lab[rowIndex, colIndex] = ' ';
        }

        public static bool CanPassThroughCell(int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || colIndex < 0)
            {
                return false;
            }
            
            if (rowIndex >= lab.GetLength(0) || colIndex >= lab.GetLength(1))
            {
                return false;
            }

            if (lab[rowIndex, colIndex] == 'x' || lab[rowIndex, colIndex] == '-')
            {
                return false;
            }

            return true;
        }
    }
}
