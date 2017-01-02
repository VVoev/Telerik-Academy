using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ThirdBit
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32,'0'));
        int result = (1 << 3) & n;
        int bitPosition = result >> 3;
        Console.WriteLine(bitPosition);
    }
}
