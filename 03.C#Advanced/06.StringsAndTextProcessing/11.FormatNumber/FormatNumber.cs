using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class FormatNumber
{
    static void Main()
    {
        decimal number = decimal.Parse(Console.ReadLine());
        Console.WriteLine("{0:F15}", number);
        Console.WriteLine(Convert.ToString((int)number,16).PadRight(15,'0'));
        Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                 "{0:#0.##%}", number));
        Console.WriteLine(String.Format(CultureInfo.InvariantCulture,
                                "{0:0.###E+0}", number));
    }
}
