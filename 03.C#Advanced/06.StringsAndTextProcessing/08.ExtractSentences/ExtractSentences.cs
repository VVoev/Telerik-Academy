using System;
using System.Linq;
using System.Text;

class ExtractSentences
{
    static void Main()
    {
        string matchWord = Console.ReadLine()
                                  .ToLower();

        string text = Console.ReadLine();

        string[] sentences = text.Split('.')
                                 .ToArray();

        // Extract unique characters in array.
        char[] separators = ExtractUniqueSeparators(text);

        StringBuilder filteredSentences = new StringBuilder();

        for (int i = 0; i < sentences.Length; i++)
        {

            // Separate words by none letter symbols.
            var words = sentences[i].ToLower()
                                    .Split(separators)
                                    .ToArray();

            // Check for match word.
            bool isMatchWord = words.Any(x => x == matchWord);

            // Add sentence if word is match in current sentence.
            if (isMatchWord)
            {
                filteredSentences.Append(sentences[i] + ".");
            }
        }

        // Print result.
        Console.WriteLine(string.Join(" ", filteredSentences));
    }

    static char[] ExtractUniqueSeparators(string text)
    {
        char[] separators = text.Where(x => !char.IsLetter(x) && x != '.') // Add separator if it is not a letter or '.'.
                                .Distinct() // Remove repeated characters.
                                .ToArray(); // Add separators in array.
        return separators;
    }
}