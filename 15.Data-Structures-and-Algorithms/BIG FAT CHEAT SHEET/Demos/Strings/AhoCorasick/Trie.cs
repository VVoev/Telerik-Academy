using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhoCorasick
{
    public class Trie
    {
        private readonly Dictionary<char, Trie> children;
        private string pattern;
        private Trie failLink;

        public Trie()
        {
            this.pattern = null;
            this.children = new Dictionary<char, Trie>();
        }

        public void AddString(string text)
        {
            var currentNode = this;
            foreach (var c in text)
            {
                if (!currentNode.children.ContainsKey(c))
                {
                    currentNode.children[c] = new Trie();
                }

                currentNode = currentNode.children[c];
            }

            currentNode.pattern = text;
        }

        public void DFS()
        {
            this.DFS(string.Empty);
        }

        public void Precompute()
        {
            var queue = new Queue<Trie>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();

                foreach (var child in currentNode.children)
                {
                    var failNode = currentNode.failLink;
                    while (failNode != null && !failNode.children.ContainsKey(child.Key))
                    {
                        failNode = failNode.failLink;
                    }

                    child.Value.failLink = failNode == null ? null : failNode.children[child.Key];
                    queue.Enqueue(child.Value);
                }
            }
        }

        private void DFS(string str)
        {
            if (this.pattern != null)
            {
                Console.WriteLine(str);
            }

            foreach (var child in this.children)
            {
                child.Value.DFS(str + child.Key);
            }
        }

        public void AhoCorasick(string text)
        {
            var currentNode = this;
            for (int i =0; i < text.Length; i++)
            {
                while (currentNode != null && !currentNode.children.ContainsKey(text[i]))
                {
                    currentNode = currentNode.failLink;
                }

                currentNode = currentNode == null ? this : currentNode.children[text[i]];

                var nodeToCheck = currentNode;

                while (nodeToCheck != null)
                {
                    if (nodeToCheck.pattern != null)
                    {
                        PrintMatch(i + 1 - nodeToCheck.pattern.Length, nodeToCheck.pattern);
                    }

                    nodeToCheck = nodeToCheck.failLink;
                }
                if (currentNode.pattern != null)
                {
                    PrintMatch(i - currentNode.pattern.Length + 1, currentNode.pattern);
                }
            }
        }

        public void PrintMatch(int index, string pattern)
        {
            Console.Write(new string(' ', index));
            Console.WriteLine(pattern);
        }

        //private void PrintMe()
        //{
        //    if (this.pattern != null)
        //    {
        //        Console.WriteLine(this.pattern);
        //        return;
        //    }

        //    var firstChild = this.children.First();
        //    firstChild.Value.PrintMe();
        //}
    }
}
