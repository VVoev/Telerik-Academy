using System.Collections.Generic;

namespace _05.TreesAndTraversals
{
    public class TreeNode
    {
        public int Value { get; set; }

        public List<TreeNode> Children { get; set; }

        public TreeNode(int value)
        {
            this.Value = value;
            this.Children = new List<TreeNode>();
        }
    }
}
