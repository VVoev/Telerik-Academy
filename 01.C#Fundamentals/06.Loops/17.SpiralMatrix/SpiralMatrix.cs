using System;

class SpiralMatrix
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int max = n * n;
        int[,] spiral = new int[n, n];
        FillSpiralMatrix(n, max, spiral);
        PrintSpiralMatrix(n, spiral);
    }

    static void FillSpiralMatrix(int n, int max, int[,] spiral)
    {
        int row = 0;
        int col = 0;
        string startDir = "right";
        for (int i = 1; i <= max; i++)
        {
            // Check if next cell in matrix is empty. If it's not empty update direction.
            UpdateDirection(n, spiral, ref row, ref col, ref startDir);
            // Add number to matrix.
            spiral[row, col] = i;
            // Update row || col depending on direction.
            UpdateRowOrCol(ref row, ref col, startDir);
        }
    }

    static void UpdateRowOrCol(ref int row, ref int col, string startDir)
    {
        if (startDir == "right")
        {
            col++;
        }
        else if (startDir == "down")
        {
            row++;
        }
        else if (startDir == "left")
        {
            col--;
        }
        else if (startDir == "up")
        {
            row--;
        }
    }

    static void UpdateDirection(int n, int[,] spiral, ref int row, ref int col, ref string startDir)
    {
        if (startDir == "right" && (col > n - 1 || spiral[row, col] != 0))
        {
            startDir = "down";
            row++;
            col--;
        }
        else if (startDir == "down" && (row > n - 1 || spiral[row, col] != 0))
        {
            startDir = "left";
            col--;
            row--;
        }
        else if (startDir == "left" && (col < 0 || spiral[row, col] != 0))
        {
            startDir = "up";
            col++;
            row--;
        }
        else if (startDir == "up" && (row < 0 || spiral[row, col] != 0))
        {
            startDir = "right";
            col++;
            row++;
        }
    }

    static void PrintSpiralMatrix(int n, int[,] spiral)
    {
        //Display spiral matrix
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0} ", spiral[i, j]);
            }
            Console.WriteLine();
        }
    }
}
