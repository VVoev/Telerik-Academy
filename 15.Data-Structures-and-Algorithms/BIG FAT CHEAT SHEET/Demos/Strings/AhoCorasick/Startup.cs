using System.Linq;

namespace AhoCorasick
{
    public class Startup
    {
        public static void Main()
        {
            var strings = new string[]
            {
                "a",
                "aa",
                "aaa",
                "aaaa",
            };

            var trie = new Trie();
            strings.ToList().ForEach(x => trie.AddString(x));

            //trie.DFS();

            trie.Precompute();

            string text = "aaaaa";
            System.Console.WriteLine(text);

            trie.AhoCorasick(text);
        }
    }
}
