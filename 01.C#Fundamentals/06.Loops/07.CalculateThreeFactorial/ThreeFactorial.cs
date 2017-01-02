using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class ThreeFactorial
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        BigInteger factorielN = 1;
        BigInteger factorielK = 1;
        BigInteger factorielNminusK = 1;
        if (n == 0 || k == 0)
        {
            factorielN = 0;
            factorielK = 0;
            Console.WriteLine(0);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                factorielN *= (i + 1);
            }
            for (int j = 0; j < k; j++)
            {
                factorielK *= (j + 1);
            }
            for (int secondFactoriel = 0; secondFactoriel < n - k; secondFactoriel++)
            {
                factorielNminusK *= (secondFactoriel + 1);
            }
            Console.WriteLine((factorielN / (factorielK * factorielNminusK)));
        }
    }
}
