using System;
using System.Numerics;

class CatalanNumber
{
    static void Main()
    {
        int num = int.Parse(Console.ReadLine());
        BigInteger firstFac = 1;
        BigInteger secondFac = 1;
        BigInteger thirdFac = 1;

        for (int i = 1; i <= 2 * num; i++)
        {
            firstFac *= i;
        }
        for (int j = 1; j <= num + 1; j++)
        {
            secondFac *= j;
        }
        for (int k = 1; k <= num; k++)
        {
            thirdFac *= k;
        }

        Console.WriteLine(firstFac / (secondFac * thirdFac));
    }
}