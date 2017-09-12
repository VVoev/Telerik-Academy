using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionsRepeatingCharacters
{
  class Program
  {
    static void Main()
    {
      string text = "A regular expression is a set of patterns used to match character combinations in strings";

      List<string> patters = new List<string> { "\\w*", "\\w+", "\\w?" };

      patters.ForEach(pattern =>
      {
        var matches = Regex.Matches(text, pattern);
        Console.WriteLine("---Matches for {0} (each match is on a separate line)", pattern);
        foreach (var match in matches)
        {
          Console.WriteLine(match);
        }
        Console.WriteLine("-------------------");
      });
    }
  }
}
