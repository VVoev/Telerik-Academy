using System;

class FactorialTrailingZeros
{
    static void Main()
    {
        int numberFactoriel = int.Parse(Console.ReadLine());
        int factorielZeros = 0;

        for (int i = 5; i < numberFactoriel; i*=5)
        {
                factorielZeros += numberFactoriel / i;
        }
        Console.WriteLine(factorielZeros);
    }
}
