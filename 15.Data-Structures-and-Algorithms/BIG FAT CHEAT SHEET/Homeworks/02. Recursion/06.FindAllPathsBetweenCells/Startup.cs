using System;
using System.Collections.Generic;

/*
 * 7. We are given a matrix of passable and non-passable cells. 
 * Write a recursive program for finding all paths between two cells in the matrix.
 */

namespace _06.FindAllPathsBetweenCells
{
    public class Startup
    {
        private static readonly char[,] labyrinth =
       {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ' },
            { '*', '*', ' ', '*', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
            { ' ', '*', '*', '*', '*', '*', ' ' },
            { ' ', ' ', ' ', ' ', ' ', ' ', 'e' },
        };

        private static List<char[,]> possiblePaths = new List<char[,]>();

        public static void Main()
        {
            FindPaths(labyrinth, 0, 0);
            PrintAllPossiblePaths();
        }

        private static void FindPaths(char[,] labrynth, int rowIndex, int colIndex)
        {
            if (rowIndex < 0 || rowIndex >= labrynth.GetLength(0))
            {
                return;
            }

            if (colIndex < 0 || colIndex >= labrynth.GetLength(1))
            {
                return;
            }

            if (labrynth[rowIndex, colIndex] == '*' || labrynth[rowIndex, colIndex] == '-')
            {
                return;
            }

            if (labrynth[rowIndex, colIndex] == 'e')
            {
                SavePath();
                return;
            }

            labrynth[rowIndex, colIndex] = '-';

            FindPaths(labrynth,rowIndex, colIndex + 1);
            FindPaths(labrynth, rowIndex + 1, colIndex);

            FindPaths(labrynth, rowIndex, colIndex - 1);
            FindPaths(labrynth, rowIndex - 1, colIndex);

            labrynth[rowIndex, colIndex] = ' ';
        }

        private static void SavePath()
        {
            char[,] pathToAdd = new char[labyrinth.GetLength(0), labyrinth.GetLength(1)];
            for (int i  =0; i < labyrinth.GetLength(0); i++)
            {
                for (int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    pathToAdd[i, j] = labyrinth[i, j];
                }
            }

            possiblePaths.Add(pathToAdd);
        }

        private static void PrintAllPossiblePaths()
        {
            foreach (var possiblePath in possiblePaths)
            {
                for (int row = 0; row < possiblePath.GetLength(0); row++)
                {
                    for (int col = 0; col < possiblePath.GetLength(1); col++)
                    {
                        Console.Write(possiblePath[row, col] + " ");
                    }

                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }
    }
}
