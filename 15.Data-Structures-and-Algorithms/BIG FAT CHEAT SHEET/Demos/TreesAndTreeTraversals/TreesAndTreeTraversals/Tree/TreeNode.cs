namespace TreesAndTreeTraversals.Tree
{
    public class TreeNode<T>
    {
        public TreeNode(T value)
        {
            this.Value = value;
        }

        public TreeNode(T value, TreeNode<T> left, TreeNode<T> right)
            : this(value)
        {
            this.Left = left;
            this.Right = right;
        }

        public TreeNode<T> Left { get; private set; }

        public TreeNode<T> Right { get; private set; }

        public T Value { get; set; }

        public bool IsLeaf
        {
            get
            {
                return this.Left == null && this.Right == null;
            }
        }
    }
}
