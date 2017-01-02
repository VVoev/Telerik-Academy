using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class WordDictionary
{
    static void Main()
    {
        Dictionary<string, string> wordExplanation = new Dictionary<string, string>()
        {
            {".NET","platform for applications from Microsoft" },
            {"CLR", "managed execution environment for .NET"},
            {"namespace","hierarchical organization of classes" }
        };
        string word = string.Empty;
        try
        {
            word = Console.ReadLine();
        }
        catch (Exception)
        {

            Console.WriteLine("The word is not in the dictionary.");
        }
        
        Console.WriteLine(wordExplanation[word]);
    }
}
