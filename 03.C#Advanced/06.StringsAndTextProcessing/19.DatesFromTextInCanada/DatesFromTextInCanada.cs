using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class DatesFromTextInCanada
{
    static void Main()
    {
        // Not completely full regex pattern.
        string randomText = Console.ReadLine();
        string pattern = @"(([0-1][0-9]{1})|([3][0-1]{1}))\.(([0][0-9]{1})|([1][0-2]{1}))\.[\d]{4}";
        Regex rgx = new Regex(pattern);
        MatchCollection dates = rgx.Matches(randomText);
        foreach (Match date in dates)
        {
            CultureInfo canada = new CultureInfo("en-Ca");
            DateTime canadianDate = DateTime.ParseExact(date.ToString(), "dd.MM.yyyy", canada);

            Console.WriteLine(canadianDate);
        }
    }
}

