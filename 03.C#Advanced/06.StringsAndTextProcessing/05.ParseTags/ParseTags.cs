using System;
using System.Text;

class ParseTags
{
    static void Main()
    {
        string[] randomText = Console.ReadLine().Split( '>', '<', '/');
        StringBuilder finalText = new StringBuilder();
        int count = 0;
        for (int i = 0; i < randomText.Length; i++)
        {
            MakePhraseUppercase(randomText, count, i);
            count = UpdateOpeningAndClosingTag(randomText, count, i);
            ConcatanateFinalText(randomText, finalText, i);
        }
        Console.WriteLine(string.Join(" ", finalText));
    }

    static void ConcatanateFinalText(string[] randomText, StringBuilder finalText, int i)
    {
        if (randomText[i] != "" && randomText[i] != "upcase" && randomText[i] != " ")
        {
            finalText.Append(randomText[i]);
        }
    }

    static void MakePhraseUppercase(string[] randomText, int count, int i)
    {
        if (count > 0 && randomText[i] != "upcase")
        {
            randomText[i] = randomText[i].ToUpper();
        }
    }

    static int UpdateOpeningAndClosingTag(string[] randomText, int count, int i)
    {
        if (randomText[i] == "upcase")
        {
            if (count == 1)
            {
                count = 0;
            }
            else
            {
                count = 1;
            }
        }

        return count;
    }
}
