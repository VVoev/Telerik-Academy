using System;
using System.Text;
using System.Text.RegularExpressions;

class ReplaceTag
{
    static void Main(string[] args)
    {
        string htmlText = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        string pattern = @"<a href=(""|')([a-zA-Z0-9/\:\. \#]+)\1>([a-zA-Z0-9 \#]+)<\/a>";
        string replacement = @"[$3]($2)";

        Regex rgx = new Regex(pattern);
        result.AppendLine(Regex.Replace(htmlText, pattern, replacement)
                               .TrimStart('"')
                               .TrimEnd('"'));

        Console.Write(result);
    }
}