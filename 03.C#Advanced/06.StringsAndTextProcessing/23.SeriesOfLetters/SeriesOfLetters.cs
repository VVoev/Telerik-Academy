using System;
using System.Text.RegularExpressions;

class SeriesOfLetters
{
    static void Main()
    {
        string input = Console.ReadLine();
        string pattern = @"([a-zA-z])\1+";
        string replacement = "$1";
        Regex rgx = new Regex(pattern);
        string replacedText = Regex.Replace(input, pattern, replacement);
        Console.WriteLine(replacedText);
    }
}
