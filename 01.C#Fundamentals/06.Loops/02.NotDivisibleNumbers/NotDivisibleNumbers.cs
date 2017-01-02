using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NotDivisibleNumbers
{
    static void Main()
    {
        uint finalNumber = uint.Parse(Console.ReadLine());

        for (int i = 1; i <= finalNumber; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.Write("{0} ", i);
            }
        }
        Console.WriteLine();
    }
}
