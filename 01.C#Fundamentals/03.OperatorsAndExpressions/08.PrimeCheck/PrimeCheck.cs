using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class PrimeCheck
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        bool isPrime = true;
        if (n <= 1)
        {
            Console.WriteLine("false");
        }
        else if (n <= 100)
        {
            for (int count = 2; count <= Math.Sqrt(n); count++)
            {
                if (n % count == 0)
                {
                    isPrime = false;
                    Console.WriteLine("false");
                    break;
                }
            }
            if (isPrime)
            {
                Console.WriteLine("true");
            }
        }
    }
}
