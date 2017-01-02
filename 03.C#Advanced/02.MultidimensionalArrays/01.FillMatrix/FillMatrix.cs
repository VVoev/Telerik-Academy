using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FillMatrix
{
    static void Main()
    {
        //Console.Write("Enter the define matrix size:");
        int n = int.Parse(Console.ReadLine());
        //Console.Write("Enter type of matrix from 'A' to 'D':");
        string chosenMatrix = Console.ReadLine().ToLower();

        switch (chosenMatrix)
        {
            case "a":
                int[,] A = PrintMatrixA(n);
                PrintChosenMatrix(A);
                break;
            case "b":
                int[,] B = PrintMatrixB(n);
                PrintChosenMatrix(B);
                break;
            case "c":
                int[,] C = PrintMatrixC(n);
                PrintChosenMatrix(C);
                break;
            case "d":
                int[,] D = PrintMatrixD(n);
                PrintChosenMatrix(D);
                break;
            default:
                Console.WriteLine("Incorrect matrix choice.");
                break;


        }
    }
    static void PrintChosenMatrix(int[,] matrix)
    {
        for (int rows = 0; rows < matrix.GetLength(0); rows++)
        {

            for (int cols = 0; cols < matrix.GetLength(0); cols++)
            {
                Console.Write("{0}", matrix[rows, cols]);
                if (cols < matrix.GetLength(0) - 1)
                {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }
    static int[,] PrintMatrixA(int n)
    {
        int max = n * n;
        int[,] matrix = new int[n, n];
        int row = 0;
        int col = 0;
        // Fill the matrix in every column, when last row is reached add a column.
        for (int i = 1; i <= max; i++)
        {
            if (row > n - 1)
            {
                col++;
                row = 0;
            }
            matrix[row, col] = i;
            row++;
        }
        return matrix;
    }
    static int[,] PrintMatrixB(int n)
    {
        int max = n * n;
        int[,] matrix = new int[n, n];
        string direction = "down";
        int row = 0;
        int col = 0;
        // Fill the matrix starting from row 0 and column and moves down.
        // When last row is reached add column and change direction to up.
        for (int i = 1; i <= max; i++)
        {
            if (direction == "down" && row > n - 1)
            {
                col++;
                row--;
                direction = "up";
            }
            else if (direction == "up" && row < 0)
            {
                col++;
                row++;
                direction = "down";
            }

            matrix[row, col] = i;
            if (direction == "down")
            {
                row++;
            }
            else if (direction == "up")
            {
                row--;
            }
        }
        return matrix;
    }
    static int[,] PrintMatrixC(int n)
    {
        int max = n * n;
        int[,] matrix = new int[n, n];
        int row = 0;
        int col = 0;
        int number = 1;
        // Fill the down diagonal matrix. Start from last row and column 0.
        for (int i = n - 1; i >= 0; i--)
        {
            row = i;
            col = 0;
            while (row < n && col < n)
            {
                matrix[row, col] = number;
                number++;
                row++;
                col++;
            }
        }
        // Fill upper diagonal matrix. Start from row 0 and column 1.
        for (int j = 1; j <= n - 1; j++)
        {
            row = 0;
            col = j;
            while (row < n && col < n)
            {
                matrix[row, col] = number;
                number++;
                row++;
                col++;
            }
        }
        return matrix;
    }
    static int[,] PrintMatrixD(int n)
    {
        int[,] matrix = new int[n, n];
        int max = n * n;
        string direction = "down";
        int row = 0;
        int col = 0;
        // Fill matrix in spiral way starting from row 0 and column 0.
        // When last row or column is reached or next position is filled change direction.
        // Directions are in this order down -> right -> up -> left.
        for (int i = 1; i <= max; i++)
        {
            if (direction == "down" && (row > n - 1 || matrix[row, col] != 0))
            {
                row--;
                col++;
                direction = "right";
            }
            else if (direction == "right" && (col > n - 1 || matrix[row, col] != 0))
            {
                row--;
                col--;
                direction = "up";
            }
            else if (direction == "up" && (row < 0 || matrix[row, col] != 0))
            {
                row++;
                col--;
                direction = "left";
            }
            else if (direction == "left" && (col < 0 || matrix[row, col] != 0))
            {
                row++;
                col++;
                direction = "down";
            }
            matrix[row, col] = i;
            if (direction == "down")
            {
                row++;
            }
            else if (direction == "right")
            {
                col++;
            }
            else if (direction == "up")
            {
                row--;
            }
            else if (direction == "left")
            {
                col--;
            }
        }
        return matrix;
    }
}
