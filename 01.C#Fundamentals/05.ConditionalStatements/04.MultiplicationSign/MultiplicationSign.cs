using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class MultiplicationSign
{
    static void Main()
    {
        double a = double.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        bool allNumbersAreNegative = (a < 0) && (b < 0) && (c < 0);
        bool twoAreNegative = (a < 0 && b < 0 && c > 0) || (b < 0 && c < 0 && a > 0) || (a < 0 && c < 0 && b > 0);
        bool oneNumberIsNegative = (a < 0) || (b < 0) || (c < 0);
        bool oneNumberIsZero = (a == 0) || (b == 0) || (c == 0);
        if (oneNumberIsZero)
        {
            Console.WriteLine(0);
        }
        else if (twoAreNegative)
        {
            Console.WriteLine("+");
        }
        else if (allNumbersAreNegative || oneNumberIsNegative)
        {
            Console.WriteLine("-");
        }
        else
        {
            Console.WriteLine("+");
        }
    }
}
