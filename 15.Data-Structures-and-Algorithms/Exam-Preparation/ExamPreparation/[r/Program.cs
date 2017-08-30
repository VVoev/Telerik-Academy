using System;
using System.Linq;

class Program
{
    public const int BLOCK = -1;
    public static int startRow = 0;
    public static int startCol = 0;
    public static long sum = 0;
    public static int[,] matrix;
    private static bool[,] visited;
    static void Main(string[] args)
    {
        //VladoSolution.Test();

        var startingPosition = Console.ReadLine().Split(' ');
        startRow = int.Parse(startingPosition[0]);
        startCol = int.Parse(startingPosition[1]);

        var matrixDimensions = Console.ReadLine().Split(' ');
        var matrixRow = int.Parse(matrixDimensions[0]);
        var matrixCol = int.Parse(matrixDimensions[1]);

        matrix = new int[matrixRow, matrixCol];
        visited = new bool[matrixRow, matrixCol];

        for (int row = 0; row < matrixRow; row++)
        {
            var line = Console.ReadLine().Split(' ');
            for (int col = 0; col < matrixCol; col++)
            {
                var symbol = line[col];
                var number = symbol == "#" ? BLOCK : int.Parse(symbol);
                matrix[row, col] = number;
            }
        }

        long curentSum = 0;
        Recurssion(matrix, startRow, startCol,curentSum);
        Console.WriteLine(sum);
        //Debugging purposes
        //Print(matrix);
    }

    private static void Recurssion(int[,] matrix, int startRow, int startCol,long currentSum)
    {
        if (matrix[startRow, startCol] == BLOCK)
        {
            //Frogs
        }

        if (visited[startRow, startCol])
        {
            return;
        }

        currentSum += matrix[startRow, startCol];
        if (currentSum > sum)
        {
            sum = currentSum;
        }



        visited[startRow, startCol] = true;
        var currentNumber = matrix[startRow, startCol];

        //Up
        if (startRow - currentNumber >= 0 && (matrix[startRow - currentNumber, startCol] != BLOCK))
        {
            var up = startRow - currentNumber;
            CheckIfinRange(matrix, startCol, currentSum, up);
        }
        //Down
        if (startRow + currentNumber < matrix.GetLength(0) && (matrix[startRow + currentNumber, startCol] != BLOCK))
        {
            var down = startRow + currentNumber;
            //Console.WriteLine(matrix[down, startCol]);
            CheckIfinRange(matrix, down, currentSum, startCol);
            //Recurssion(matrix, down, startCol, currentSum);
        }
        //Left
        if (startCol - currentNumber >= 0 && (matrix[startRow, startCol - currentNumber] != BLOCK))
        {
            var left = startCol - currentNumber;
            //Console.WriteLine(matrix[startRow,left]);
            CheckIfinRange(matrix, startRow, currentSum, left);
            //Recurssion(matrix, startRow, left, currentSum);
        }
        //Right
        if (startCol + currentNumber < matrix.GetLength(1) && (matrix[startRow, startCol + currentNumber] != BLOCK))
        {
            var right = startCol + currentNumber;
            //Console.WriteLine(matrix[startRow, right]);
            CheckIfinRange(matrix, startRow, currentSum, right);
            //Recurssion(matrix, startRow, right, currentSum);
        }

        visited[startRow, startCol] = false;
    }

    private static void CheckIfinRange(int[,] matrix, int startCol, long currentSum, int up)
    {
        if (!(up - matrix[up, startCol] < 0 || matrix[up - matrix[up, startCol], startCol] == BLOCK) &&
                        (up + matrix[up, startCol] >= matrix.GetLength(0) || matrix[up + matrix[up, startCol], startCol] == BLOCK) &&
                        (startCol + matrix[up, startCol] >= matrix.GetLength(0) || matrix[up, startCol + matrix[up, startCol]] == BLOCK) &&
                        (startCol - matrix[up, startCol] < 0 || matrix[up, startCol - matrix[up, startCol]] == BLOCK))
        {
            //Console.WriteLine(matrix[up,startCol]);
            Recurssion(matrix, up, startCol, currentSum);
        }
    }

    private static void Print(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

