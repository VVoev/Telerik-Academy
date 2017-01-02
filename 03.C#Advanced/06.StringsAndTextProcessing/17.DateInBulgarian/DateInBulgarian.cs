using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DateInBulgarian
{
    static void Main()
    {
        CultureInfo bulgaria = new CultureInfo("bg-BG");
        DateTime bulgarianDate = DateTime.ParseExact("10.10.2016", "dd.MM.yyyy", bulgaria);
        Console.WriteLine(bulgarianDate);
    }
}
