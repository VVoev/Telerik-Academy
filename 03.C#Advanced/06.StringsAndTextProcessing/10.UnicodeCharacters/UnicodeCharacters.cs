using System;

class UnicodeCharacters
{
    static void Main()
    {
        char[] text = Console.ReadLine().ToCharArray();
        foreach (var ch in text)
        {
            Console.Write("\\u" + ((int)ch).ToString("X4"));
        }
        Console.WriteLine();
    }
}
