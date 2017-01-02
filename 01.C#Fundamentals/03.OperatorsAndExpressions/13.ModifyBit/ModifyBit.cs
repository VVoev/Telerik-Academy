using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ModifyBit
{
    static void Main()
    {
        ulong n = ulong.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int v = int.Parse(Console.ReadLine());
        // Check for bit in position p
        ulong mask = (ulong)1 << p;
        ulong result = n & mask;
        int bitPosition = (int)result >> p;
        //Console.WriteLine(Convert.ToString(bitPosition, 2).PadLeft(32, '0'));
        if (bitPosition == v)
        {
            Console.WriteLine(n);
        }
        else if (bitPosition == 1)
        {
            n = n & ~((ulong)1 << p);
            Console.WriteLine(n);
        }
        else if (bitPosition == 0)
        {
            n = n | ((ulong)1 << p);
            Console.WriteLine(n);
        }
    }
}
