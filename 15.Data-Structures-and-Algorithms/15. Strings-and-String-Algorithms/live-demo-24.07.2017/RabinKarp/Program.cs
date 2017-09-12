using System;

namespace RabinKarp
{
    class Program
    {
        static void PrintMatch(int index, string pattern)
        {
            for (int i = 0; i < index; ++i)
            {
                Console.Write(" ");
            }

            Console.WriteLine(pattern);
        }

        static void Main()
        {
            var pattern = "alabala";
            var text = "xalabalabala";

            var patternHash = new Hash(pattern);
            var windowHash = new Hash(text, pattern.Length);

            Console.WriteLine(text);

            if (patternHash.Equals(windowHash))
            {
                PrintMatch(0, pattern);
            }

            for (int i = 0; i < text.Length - pattern.Length; i++)
            {
                windowHash.Roll(
                    text[i + pattern.Length],
                    text[i]);

                if (patternHash.Equals(windowHash))
                {
                    PrintMatch(i + 1, pattern);
                }
            }
        }
    }
}
