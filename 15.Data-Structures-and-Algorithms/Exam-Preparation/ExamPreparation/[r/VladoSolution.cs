using System;
using System.Linq;

class VladoSolution
{
    private static int rows;
    private static int cols;

    private static bool[,] visited;

    private static int max = 0;

    public static void Test()
    {
        int[] startingLocation = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
        rows = sizes[0];
        cols = sizes[1];

        int[,] matrix = new int[rows, cols];
        int sum = 0;
        visited = new bool[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            string[] line = Console.ReadLine().Split();
            for (int j = 0; j < cols; j++)
            {
                if (line[j] == "#")
                {
                    matrix[i, j] = -1;
                }
                else
                {
                    matrix[i, j] = int.Parse(line[j]);
                }
            }
        }

        int result = Move(matrix, startingLocation[0], startingLocation[1], sum);

        Console.WriteLine(max);
    }

    private static int Move(int[,] matrix, int row, int col, int sum)
    {
        if (row >= rows || row < 0 || col >= cols || col < 0 || matrix[row, col] == -1)
        {
            return sum;
        }

        if (visited[row, col])
        {
            return sum;
        }

        // check if future cell has no moves
        if ((row + matrix[row, col] >= rows || matrix[row + matrix[row, col], col] == -1) &&
            (row - matrix[row, col] < 0 || matrix[row - matrix[row, col], col] == -1) &&
            (col + matrix[row, col] >= cols || matrix[row, col + matrix[row, col]] == -1) &&
            (col - matrix[row, col] < 0 || matrix[row, col - matrix[row, col]] == -1))
        {
            return sum;
        }

        sum += matrix[row, col];
        if (sum > max)
        {
            max = sum;
        }

        visited[row, col] = true;

        Move(matrix, row + matrix[row, col], col, sum);
        Move(matrix, row - matrix[row, col], col, sum);
        Move(matrix, row, col + matrix[row, col], sum);
        Move(matrix, row, col - matrix[row, col], sum);

        visited[row, col] = false;

        return sum;
    }
}