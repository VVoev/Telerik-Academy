using System;

class MatrixNumbers
{
    static void Main()
    {
        int matrixNumber = int.Parse(Console.ReadLine());

        for (int columns = 1; columns <= matrixNumber; columns++)
        {
            for (int rows = columns; rows <= columns + matrixNumber - 1; rows++)
            {
                Console.Write("{0} ", rows);
            }
            Console.WriteLine();
        }
    }
}
