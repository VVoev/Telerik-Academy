using System;
using System.Collections;
using System.Collections.Generic;

namespace AvlTreeRecursive
{
    public class AvlTree<T> : IEnumerable<T>
        where T : IComparable<T>
    {
        private AvlNode<T> root;

        public int Count => AvlNode<T>.GetSize(root);
        public int Height => AvlNode<T>.GetHeight(root);

        public AvlTree()
        {
            root = null;
        }

        public bool Contains(T value)
        {
            return AvlNode<T>.Contains(this.root, value);
        }

        public int IndexOf(T value)
        {
            return AvlNode<T>.IndexOf(this.root, value);
        }

        public T AtIndex(int index)
        {
            return AvlNode<T>.AtIndex(this.root, index);
        }

        public bool Add(T value)
        {
            return AvlNode<T>.Add(ref this.root, value);
        }

        public bool Remove(T value)
        {
            return AvlNode<T>.Remove(ref this.root, value);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var stack = new Stack<Tuple<AvlNode<T>, bool>>();
            stack.Push(new Tuple<AvlNode<T>, bool>(this.root, false));

            while (stack.Count > 0)
            {
                var tuple = stack.Pop();
                var node = tuple.Item1;
                var isLeftTraversed = tuple.Item2;

                if (node == null)
                {
                    continue;
                }

                if (!isLeftTraversed)
                {
                    stack.Push(new Tuple<AvlNode<T>, bool>(node, true));
                    stack.Push(new Tuple<AvlNode<T>, bool>(node.Left, false));
                }
                else
                {
                    yield return node.Value;
                    stack.Push(new Tuple<AvlNode<T>, bool>(node.Right, false));
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
