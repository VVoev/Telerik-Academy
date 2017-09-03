using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarp
{
    public class Startup
    {
        private const int BaseSystem = 127;
        private const int Mod = 1000000007;

        public static void Main()
        {
            string pattern = "alabala";
            string text = "alabalabafadsfadsfasdfalabalaadsfadsfasdfasdfala";

            var patternHash = new RollingHash(BaseSystem, Mod, pattern);
            var textHash = new RollingHash(BaseSystem, Mod, text, pattern.Length);

            if (textHash.Equals(patternHash))
            {
                PrintMatch(0, pattern);
            }
            
            for (int i = 1; i < text.Length - pattern.Length + 1; i++)
            {
                textHash.Roll(text[i - 1], text[i + pattern.Length - 1]);

                if (patternHash.Equals(textHash))
                {
                    PrintMatch(i, pattern);
                }
            }
        }

        public static bool AreStringsEqual(string first, string second)
        {
            return first == second;
        }

        public static void PrintMatch(int index, string match)
        {
            for (int i  =0; i < index; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(match);
        }
    }
}
