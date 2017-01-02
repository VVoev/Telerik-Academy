using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrimeNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<int> num = new List<int>();

        double maxPrimeCheck = Math.Sqrt(n);
        for (int i = 2; i <= maxPrimeCheck; i++)
        {
            if (!num.Contains(i))
            {
                num.Add(i);
            }
            if (num[i] == 0)
            {
                int p = 2 * i;
                while (p <= n)
                {
                    num[p] = 2;
                    p += i;
                }
            }
        }
        int lastIndex = num.Length - 1;
        while (num[lastIndex] != 0)
        {
            lastIndex--;
        }
        Console.WriteLine(lastIndex);
    }
}
