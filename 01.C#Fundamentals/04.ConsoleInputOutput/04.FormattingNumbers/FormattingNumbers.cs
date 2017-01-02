using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FormattingNumbers
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        double b = double.Parse(Console.ReadLine());
        double c = double.Parse(Console.ReadLine());
        string hexA = Convert.ToString(a, 16).ToUpper();
        string binaryA = Convert.ToString(a, 2).PadLeft(11, '0');
        Console.WriteLine("{0} |{1}| {2:F3}|{3:F3} |", hexA, binaryA, b, c);
    }
}
