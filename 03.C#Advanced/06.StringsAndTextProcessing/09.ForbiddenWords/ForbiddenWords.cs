using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ForbiddenWords
{
    static void Main()
    {
        string text = Console.ReadLine();
        string[] sentence = Console.ReadLine().Split(' ');
        for (int i = 0; i < sentence.Length; i++)
        {
            text = text.Replace(sentence[i], new string('*', sentence[i].Length));
        }
        Console.WriteLine(text);
    }
}
