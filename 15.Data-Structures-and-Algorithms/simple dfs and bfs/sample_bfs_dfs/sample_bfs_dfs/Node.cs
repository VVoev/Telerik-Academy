using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample_bfs_dfs
{
    class Node
    {
        public Node(string data, Node left, Node right)
        {
            this.Data = data;
            this.Left = left;
            this.Right = right;
        }

        public Node(string data)
        {
            this.Data = data;
            this.Left = null;
            this.Right = null;
        }

        public string Data { get; set; }

        public Node Left { get; set; }

        public Node Right { get; set; }
    }
}
