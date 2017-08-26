using System;

class Program
{
    const int INFINITY = int.MaxValue;
    const int NORMAL_TIME = 1;
    const int SLOW_TIME = 3;

    static void Main()
    {
        var line = Console.ReadLine().Split(' ');
        var rows = int.Parse(line[0]);
        var cols = int.Parse(line[1]);

        var field = new long[rows, cols];

        var guards = int.Parse(Console.ReadLine());
        for (int i = 0; i < guards; ++i)
        {
            line = Console.ReadLine().Split(' ');
            var row = int.Parse(line[0]);
            var col = int.Parse(line[1]);
            var direction = line[2][0];

            field[row, col] = INFINITY;
            switch (direction)
            {
                case 'U':
                    if (row > 0 && field[row - 1, col] == 0)
                    {
                        field[row - 1, col] = SLOW_TIME;
                    }
                    break;
                case 'D':
                    if (row < rows - 1 && field[row + 1, col] == 0)
                    {
                        field[row + 1, col] = SLOW_TIME;
                    }
                    break;
                case 'L':
                    if (col > 0 && field[row, col - 1] == 0)
                    {
                        field[row, col - 1] = SLOW_TIME;
                    }
                    break;
                case 'R':
                    if (col < cols - 1 && field[row, col + 1] == 0)
                    {
                        field[row, col + 1] = SLOW_TIME;
                    }
                    break;
            }
        }

        for (int i = 0; i < rows; ++i)
        {
            for (int j = 0; j < cols; ++j)
            {
                if (field[i, j] == 0)
                {
                    field[i, j] = NORMAL_TIME;
                }

                if (i == 0 && j == 0)
                {
                    continue;
                }
                if (i == 0)
                {
                    field[i, j] += field[i, j - 1];
                }
                else if (j == 0)
                {
                    field[i, j] += field[i - 1, j];
                }
                else
                {
                    field[i, j] += Math.Min(field[i, j - 1], field[i - 1, j]);
                }
            }
        }

        var answer = field[rows - 1, cols - 1];
        if (answer < INFINITY)
        {
            Console.WriteLine(answer);
        }
        else
        {
            Console.WriteLine("Meow");
        }
    }
}