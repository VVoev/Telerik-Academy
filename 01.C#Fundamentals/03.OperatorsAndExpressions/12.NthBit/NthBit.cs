using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class NthBit
{
    static void Main()
    {
        long p = long.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        long result = ((long)1 << n )& p;
        //Console.WriteLine(Convert.ToString(result, 2).PadLeft(32, '0'));
        long bitPosition = result >> n;
        Console.WriteLine(bitPosition);
       
    }
}
