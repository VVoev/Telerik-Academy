using System;

namespace AhoCorasick
{
    class Program
    {
        static void Main()
        {
            var strings = new string[]
                {
                    "a",
                    "b",
                    "ab",
                    "bab",
                    "bc",
                    "bca",
                    "c",
                    "caa"
                };

            var root = new Trie();

            foreach(var str in strings)
            {
                root.AddString(str);
            }

            root.Precompute();


            var text = "asdbbasbcbascbabcbabcsabc";
            Console.WriteLine(text);
            root.AhoCorasick(text);
        }
    }
}
