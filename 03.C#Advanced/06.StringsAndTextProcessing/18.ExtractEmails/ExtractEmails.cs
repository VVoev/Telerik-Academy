using System;
using System.Linq;
using System.Text.RegularExpressions;

class ExtractEmails
{
    static void Main()
    {
        string[] text = Console.ReadLine().Split(' ').ToArray();
        string pattern = @"[\w\.\-]+@[\w\.\-]+\.{1}[\w]{2,3}";

        Regex rgx = new Regex(pattern);
        foreach (var email in text)
        {
            if (rgx.IsMatch(email))
            {
                Match extractEmails = rgx.Match(email);
                Console.WriteLine(extractEmails.Groups[0]);
            }
        }
    }
}
