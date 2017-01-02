using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

class Calculate
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double x = double.Parse(Console.ReadLine());
        double s = 1;
        for (int i = 1; i <= n; i++)
        {
            s += CalculateFactorial(i) / Math.Pow(x, i);
        }
        Console.WriteLine("{0:F5}", s);
    }
    static int CalculateFactorial(int i)
    {
        if (i <= 1)
        {
            return 1;
        }
        return i * CalculateFactorial(i - 1);
    }
}
