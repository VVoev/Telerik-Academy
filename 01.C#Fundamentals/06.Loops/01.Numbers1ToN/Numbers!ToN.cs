using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Numbers1ToN
{
    static void Main()
    {
        uint finalNumber = uint.Parse(Console.ReadLine());

        for (int i = 1; i <= finalNumber; i++)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
    }
}
