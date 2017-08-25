using System;
using System.Numerics;
using System.Linq;
class HelpDoge
{
    const int Dogevalue = -1;
    public static int fx, fy;
    static void Main()
    {

        var field = Input();

        for (int x = 0; x < field.GetLength(0); x++)
        {
            for (int y = 0; y < field.GetLength(1); y++)
            {
                if (x == 0 && y == 0)
                {
                    field[0, 0] = 1;
                    continue;
                }
                if (field[x, y] == Dogevalue)
                {
                    field[x, y] = 0;
                    continue;
                }
                if (x == 0)
                {
                    field[0, y] = field[0, y - 1];
                    continue;
                }
                if (y == 0)
                {
                    field[x, 0] = field[x - 1, 0];
                    continue;
                }
                field[x, y] = field[x - 1, y] +
                              field[x, y - 1];
            }

        }
        Console.WriteLine("{0}", field[fx, fy]);


    }

    private static BigInteger[,] Input()
    {
        //dimensions of the matrix
        var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int n = line[0];
        int m = line[1];

        //cordinate for exiting the labirinth
        line = Console.ReadLine().Split().Select(int.Parse).ToArray();
        fx = line[0];
        fy = line[1];

        BigInteger[,] field = new BigInteger[n, m];

        // enemies
        int enemies = int.Parse(Console.ReadLine());
        for (int i = 0; i < enemies; i++)
        {
            line = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int x = line[0];
            int y = line[1];
            field[x, y] = Dogevalue;
        }
        return field;
    }
}