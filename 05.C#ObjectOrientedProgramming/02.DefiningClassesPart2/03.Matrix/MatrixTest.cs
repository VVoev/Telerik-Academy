namespace _03.Matrix
{
    using System;

    public class MatrixTest
    {
        static void Main()
        {
            var firstMatrix = new GenericMatrix<int>(5, 6);
            var secondMatrix = new GenericMatrix<int>(5, 6);
            for (int i = 0; i < firstMatrix.Row; i++)
            {
                for (int j = 0; j < firstMatrix.Col; j++)
                {
                    firstMatrix[i, j] = i + 2;
                    secondMatrix[i, j] = i * 2;
                }
            }

            Console.WriteLine("First GenericMatrix");
            Console.WriteLine(PrintResultZeroElement(firstMatrix));
            Console.WriteLine(firstMatrix.ToString());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Second GenericMatrix");
            Console.WriteLine(PrintResultZeroElement(secondMatrix));
            Console.WriteLine(secondMatrix.ToString());

            // Math operations between matrices with equal sizes.
            var additionMatrix = firstMatrix + secondMatrix;
            var subtractionMatrix = firstMatrix - secondMatrix;
            var multiplicationMatrix = firstMatrix * secondMatrix;

            // Print result for operations.
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Addition between two matrix.");
            Console.WriteLine(PrintResultZeroElement(additionMatrix));
            Console.WriteLine(additionMatrix.ToString());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Subtraction between two matrix.");
            Console.WriteLine(PrintResultZeroElement(subtractionMatrix));
            Console.WriteLine(subtractionMatrix.ToString());

            Console.WriteLine("---------------------------------");
            Console.WriteLine("Multiplication between two matrix.");
            Console.WriteLine(PrintResultZeroElement(multiplicationMatrix));
            Console.WriteLine(multiplicationMatrix.ToString());

        }
        static string PrintResultZeroElement(GenericMatrix<int> matrix)
        {
            string result = string.Empty;
            if (matrix)
            {
                return result = "Current matrix has zero element.";
            }
            else
            {
                return result = "Current matrix has NOT zero element.";
            }
        }
    }
}
