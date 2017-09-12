using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
    class HuffmanTree
    {
        private HuffmanTree left;
        private HuffmanTree right;
        private char? symbol;

        public HuffmanTree(char symbol)
        {
            this.left = null;
            this.right = null;
            this.symbol = symbol;
        }

        public HuffmanTree(HuffmanTree left, HuffmanTree right)
        {
            this.left = left;
            this.right = right;
            this.symbol = null;
        }

        public void Dfs()
        {
            this.Dfs("");
        }

        private void Dfs(string str)
        {
            if (this.symbol.HasValue)
            {
                Console.WriteLine($"{this.symbol.Value}: {str}");
            }
            else
            {
                this.left.Dfs(str + "0");
                this.right.Dfs(str + "1");
            }
        }
    }
}
