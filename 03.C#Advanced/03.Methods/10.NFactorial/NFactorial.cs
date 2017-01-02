using System;
using System.Numerics;

class NFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine(CalculateFactorial(n));
    }
    static BigInteger CalculateFactorial(int number)
    {
        BigInteger factorial = 1;
        if (number == 0)
        {
            factorial = 1;
            return factorial;
        }
        for (int i = 1; i <= number; i++)
        {
            factorial *= i;
        }
        return factorial;
    }
}
