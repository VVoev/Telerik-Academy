using System;

namespace TreesDemo
{
    class Tree<T>
    {
        private T value;

        private Tree<T> left;
        private Tree<T> right;

        public Tree(T value)
            : this(value, null, null)
        {
        }

        public Tree(T value, Tree<T> left, Tree<T> right)
        {
            this.value = value;
            this.left = left;
            this.right = right;
        }

        public bool IsLeaf => left == null && right == null;

        public T Value => value;
        public Tree<T> Left => left;
        public Tree<T> Right => right;
    }
}
