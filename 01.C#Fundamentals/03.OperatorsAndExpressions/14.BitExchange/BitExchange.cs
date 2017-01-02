using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class BitExchange
{
    static void Main()
    {
        // Input data and variables.
        uint n = uint.Parse(Console.ReadLine());
        int p1 = 3;
        int p2 = 24;
        uint resultThird;
        uint result24th;
        // Main Logic.
        for (int i = 0; i < 3; i++, p2++, p1++)
        {
            uint mask = (uint)1 << p1;
            resultThird = (n & mask) >> p1;

            mask = (uint)1 << p2;
            result24th = (n & mask) >> p2;

            if (resultThird == 0)
            {
                mask = ~((uint)1 << p2);
                n = n & mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            else if (resultThird == 1)
            {
                mask = (uint)1 << p2;
                n = n | mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            if (result24th == 0)
            {
                mask = ~((uint)1 << p1);
                n = n & mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            else if (result24th == 1)
            {
                mask = (uint)1 << p1;
                n = n | mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
        }
        Console.WriteLine(n);
    }
}
