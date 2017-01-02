using System;

class IndexOfLetters
{
    static void Main()
    {
        string word = Console.ReadLine();
        for (int i = 0; i < word.Length; i++)
        {
            int index = word[i] - 'a';
            Console.WriteLine(index);
        }
    }
}
