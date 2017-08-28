using System;
using System.Linq;

class Program
{
    static int MAXVALUE = int.MaxValue;
    static int PENALTY = 3;
    static int rows;
    static int cols;
    static void Main()
    {
        var matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
        rows = matrixDimensions[0];
        cols = matrixDimensions[1];
        var matrix = new long[rows, cols];
        ReadInput(matrix);



        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                //Start Position
                if (row == 0 && col == 0)
                {
                    matrix[row, col] = 1;
                    continue;
                }
                //Guards
                if (matrix[row, col] == MAXVALUE)
                {
                    continue;
                }

                //Mark every Cell for 1 second
                if (matrix[row, col] == 0)
                {
                    matrix[row, col] = 1;
                }
                
                //You can only come from left
                if (row == 0)
                {
                    matrix[row, col] += matrix[row, col - 1];
                    continue;
                }
                //You can only come from top
                if (col == 0)
                {
                    matrix[row, col] += matrix[row - 1, col];
                    continue;
                }

                //Take the lo
                matrix[row, col] += Math.Min(matrix[row - 1, col], matrix[row, col - 1]);
            }
        }

        var answer = matrix[rows - 1, cols - 1];
        if (answer > MAXVALUE)
            Console.WriteLine("Meow");
        else
            Console.WriteLine(answer);
    }

    private static void ReadInput(long[,] matrix)
    {
        var guards = int.Parse(Console.ReadLine());
        for (int i = 0; i < guards; i++)
        {
            var guardInfo = Console.ReadLine().Split();
            var row = int.Parse(guardInfo[0]);
            var col = int.Parse(guardInfo[1]);
            char direction = char.Parse(guardInfo[2]);
            var guard = new Guard(row, col, direction);
            matrix[row, col] = MAXVALUE;

            switch (guard.Direction)
            {
                case 'U':
                    if (row > 0 && matrix[row - 1, col] == 0)
                    {
                        matrix[row - 1, col] = PENALTY;
                    }
                    break;
                case 'D':
                    if (row < rows - 1 && matrix[row + 1, col] == 0)
                    {
                        matrix[row + 1, col] = PENALTY;
                    }
                    break;
                case 'L':
                    if (col > 0 && matrix[row, col - 1] == 0)
                    {
                        matrix[row, col - 1] = PENALTY;
                    }
                    break;
                case 'R':
                    if (col < cols - 1 && matrix[row, col + 1] == 0)
                    {
                        matrix[row, col + 1] = PENALTY;
                    }
                    break;
            }
        }
    }

}
public class Guard
{
    public int Col;
    public char Direction;
    public int Row;

    public Guard(int row, int col, char direction)
    {
        this.Row = row;
        this.Col = col;
        this.Direction = direction;
    }
}