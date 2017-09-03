using System;

namespace GraphsAndGraphAlgorithms
{
    public class Printer
    {
        public void PrintMatrix<T>(T[,] matrix)
        {
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                for (int j = 1; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        public void PrintArray<T>(T[] array, string separator)
        {
            Console.WriteLine(string.Join(separator, array));
        }
    }
}
