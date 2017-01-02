using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

class ExtractTextFromHTML
{
    static void Main()
    {
        string patternForTitleText = @"<title>([A-Za-z0-9 ,\.]+)<\/title>";
        string patternForTagSplit = @"<\/?[\w=:\.\/"" ]+>";
        List<string> titles = new List<string>();
        List<string> bodyText = new List<string>();
        string input = Console.ReadLine()
                              .TrimStart()
                              .TrimEnd();

        while (input != "end")
        {

            string[] text = Regex.Split(input, patternForTagSplit);
            string titleText = Regex.Match(input, patternForTitleText)
                                    .Groups[1]
                                    .ToString();
            titles.Add(titleText);
            foreach (var t in text)
            {
                if (t != "")
                {
                    bodyText.Add(t);
                }
            }
            input = Console.ReadLine()
                           .TrimStart()
                           .TrimEnd();

        }
        Console.WriteLine("Titles: {0}", string.Join(" ",titles));
        Console.WriteLine("Text: {0}", string.Join(" ", bodyText));

    }
}
