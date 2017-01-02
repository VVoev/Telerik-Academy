using System;
using System.Numerics;

class CatalanNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        BigInteger factoriel2N = 1;
        BigInteger factorielN = 1;
        BigInteger factorielN1 = 1;
        if (n == 0)
        {
            Console.WriteLine(0);
        }
        else
        {
            factoriel2N = CalculateFactorial2N(n, factoriel2N);
            factorielN = CalculateFactorialN(n, factorielN);
            factorielN1 = CalculateFactorialNPlus1(n, factorielN1);
            Console.WriteLine(factoriel2N / (factorielN * factorielN1));
        }
    }

    static BigInteger CalculateFactorialNPlus1(int n, BigInteger factorielN1)
    {
        for (int i = 1; i <= n + 1; i++)
        {
            factorielN1 *= i;
        }

        return factorielN1;
    }

    static BigInteger CalculateFactorialN(int n, BigInteger factorielN)
    {
        for (int i = 1; i <= n; i++)
        {
            factorielN *= i;
        }

        return factorielN;
    }

    static BigInteger CalculateFactorial2N(int n, BigInteger factoriel2N)
    {
        for (int i = 1; i <= 2 * n; i++)
        {
            factoriel2N *= i;
        }

        return factoriel2N;
    }
}
