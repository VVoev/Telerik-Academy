using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegexGroups
{
  class Program
  {
    static void Main(string[] args)
    {
      string text = "A regular expression is a set of patterns used to match character combinations in strings";

      string pattern = "(\\w+) (\\w+)";

      Match match = Regex.Match(text, pattern);

      while (match.Success)
      {
        Console.WriteLine("--------------------------------");
        Console.WriteLine("Found \"{0}\"", match.Value);
        Console.WriteLine("Groups: ");

        foreach (var group in match.Groups)
        {
          Console.WriteLine("Group: \"{0}\"", group);
        }

        Console.WriteLine("--------------------------------");
        match = match.NextMatch();
      }

    }
  }
}
