using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Recurssion_Sudoku
{
    class Program
    {
        static int sudokuSize = 9; //int.Parse(Console.ReadLine());
        static int[,] sudoku = new int[sudokuSize, sudokuSize];
        static void Main(string[] args)
        {
            for (int i = 0; i < sudokuSize; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < sudokuSize; j++)
                {
                    if(line[j] == '-')
                    {
                        sudoku[i, j] = 0;
                    }
                    else
                    {
                        sudoku[i, j] = line[j] - '0';
                    }
                }
            }
            Solver(0, 0);
        }

        private static void Print(int[,] sudoku)
        {
            for (int i = 0; i < sudoku.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku.GetLength(1); j++)
                {
                    Console.Write(sudoku[i,j]+" ");
                }
                Console.WriteLine();
            }
        }
        private static void Solver(int row, int col)
        {
            if(row == sudokuSize && col == 0)
            {
                Print(sudoku);
                Console.WriteLine();
                Console.WriteLine("Press any key to kill the program");
                Console.ReadLine();
                return;
            }

            else if(sudoku[row,col] == 0)
            {
                for (int i = 1; i <= sudokuSize; i++)
                {
                    if(CheckRow(row,i) || CheckCol(col,i) || CheckSquare(row, col, i))
                    {
                        continue;
                    }

                    sudoku[row, col] = i;
                    Solver(NextRow(row, col), NextCol(row, col));
                    sudoku[row, col] = 0;
                }
            }

            else
            {
                    Solver(NextRow(row, col), NextCol(row, col));
            }
        }
        static bool CheckSquare(int row,int col,int number)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = startRow; i < startRow+3; i++)
            {
                for (int j = startCol; j < startCol+3; j++)
                {
                    if(sudoku[i,j] == number)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static bool CheckCol(int col,int number)
        {
            for (int i = 0; i < sudokuSize; i++)
            {
                if(sudoku[i,col]== number)
                {
                    return true;
                }
            }
            return false;
        }
        static bool CheckRow(int row,int number)
        {
            for (int i = 0; i < sudokuSize; i++)
            {
                if(sudoku[row,i] == number)
                {
                    return true;
                }
            }

            return false;
        }
        static int NextRow(int row, int col)
        {
            col++;
            if (col > sudokuSize-1)
            {
                return row + 1;
            }
            return row;
        }
        static int NextCol(int row,int col)
        {
            col++;
            if(col > sudokuSize-1)
            {
                return 0;
            }
            return col;
        }
    }

}
