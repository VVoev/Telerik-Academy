using System;

class StartUp
{
    static void Main()
    {
        string word = Console.ReadLine();
        string text = Console.ReadLine();

        var index = text.IndexOf(word[0]);
        int[] prefixes = new int[word.Length];
        while (index >= 0)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (index + i >= text.Length)
                {
                    break;
                }

                if (word[i] != text[index + i])
                {
                    break;
                }

                prefixes[i]++;
            }

            index = text.IndexOf(word[0], index + 1);
        }

        var suffixes = new int[word.Length];
        index = text.LastIndexOf(word[word.Length - 1]);

        while (index >= 0)
        {
            for (int i = word.Length - 1; i >= 0; i--)
            {

                if (index - (word.Length - i - 1) < 0)
                {
                    break;
                }

                char textSymbol = text[index - (word.Length - i - 1)];
                if (word[i] != textSymbol)
                {
                    break;
                }

                suffixes[i]++;
            }

            index = index > 0 ? text.LastIndexOf(word[word.Length - 1], index - 1) : -1;
        }


        var result = 0;
        for (int i = 0; i < word.Length - 1; i++)
        {
            result += prefixes[i] * suffixes[i + 1];
        }

        result += suffixes[0];
        Console.WriteLine(result);
    }
}
