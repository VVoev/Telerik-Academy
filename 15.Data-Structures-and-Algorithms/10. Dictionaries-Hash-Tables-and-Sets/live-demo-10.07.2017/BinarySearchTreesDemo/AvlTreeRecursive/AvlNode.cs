using System;
using System.Collections;
using System.Collections.Generic;

namespace AvlTreeRecursive
{
    internal class AvlNode<T>
        where T : IComparable<T>
    {
        private int size;
        private int height;

        public T Value { get; private set; }

        public AvlNode<T>[] Children { get; private set; }

        public AvlNode<T> Left
        {
            get
            {
                return Children[0];
            }
            set
            {
                Children[0] = value;
            }
        }

        public AvlNode<T> Right
        {
            get
            {
                return Children[1];
            }
            set
            {
                Children[1] = value;
            }
        }

        private int Balance => GetHeight(this.Left) - GetHeight(this.Right);

        public AvlNode(T value)
        {
            this.size = 1;
            this.height = 1;
            this.Value = value;
            this.Children = new AvlNode<T>[2];
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public static void RotateRight(ref AvlNode<T> node)
        {
            Rotate(ref node, 0, 1);
        }

        public static void RotateLeft(ref AvlNode<T> node)
        {
            Rotate(ref node, 1, 0);
        }

        public static bool Contains(AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            var cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                return Contains(node.Left, value);
            }
            if (cmp > 0)
            {
                return Contains(node.Right, value);
            }
            return true;
        }

        public static bool Add(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                node = new AvlNode<T>(value);
                return true;
            }

            var cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                var child = node.Left;
                var result = Add(ref child, value);
                if (result)
                {
                    node.Left = child;
                    BalanceIfLeftIsHeavy(ref node);
                }
                return result;
            }
            if (cmp > 0)
            {
                var child = node.Right;
                var result = Add(ref child, value);
                if (result)
                {
                    node.Right = child;
                    BalanceIfRightIsHeavy(ref node);
                }
                return result;
            }

            return false;
        }

        public static int IndexOf(AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return -1;
            }

            var cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                return IndexOf(node.Left, value);
            }
            if (cmp > 0)
            {
                return IndexOf(node.Right, value) + GetSize(node.Left) + 1;
            }
            return GetSize(node.Left);
        }

        public static T AtIndex(AvlNode<T> node, int index)
        {
            if (node == null)
            {
                throw new IndexOutOfRangeException("Noooo");
            }

            var rootIndex = GetSize(node.Left);
            if (index < rootIndex)
            {
                return AtIndex(node.Left, index);
            }
            if (index > rootIndex)
            {
                return AtIndex(node.Right, index - rootIndex - 1);
            }
            return node.Value;
        }

        public static bool Remove(ref AvlNode<T> node, T value)
        {
            if (node == null)
            {
                return false;
            }

            var cmp = value.CompareTo(node.Value);
            if (cmp < 0)
            {
                var child = node.Left;
                var result = Remove(ref child, value);
                if (result)
                {
                    node.Left = child;
                    BalanceIfRightIsHeavy(ref node);
                }
                return result;
            }
            if (cmp > 0)
            {
                var child = node.Right;
                var result = Remove(ref child, value);
                if (result)
                {
                    node.Right = child;
                    BalanceIfLeftIsHeavy(ref node);
                }
                return result;
            }

            if(node.Left == null)
            {
                node = node.Right;
            }
            else if(node.Right == null)
            {
                node = node.Left;
            }
            else
            {
                var child = node.Right;
                var replaceNode = RemoveLeftmostChild(ref child);
                node.Right = child;

                replaceNode.Left = node.Left;
                replaceNode.Right = node.Right;
                node = replaceNode;
                BalanceIfLeftIsHeavy(ref node);
            }

            return true;
        }

        private static AvlNode<T> RemoveLeftmostChild(ref AvlNode<T> node)
        {
            if(node.Left == null)
            {
                var toReturn = node;
                node = node.Right;
                return toReturn;
            }

            var child = node.Left;
            var result = RemoveLeftmostChild(ref child);
            node.Left = child;
            BalanceIfRightIsHeavy(ref node);
            return result;
        }

        private static void BalanceIfLeftIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance > 1)
            {
                if (node.Left.Balance < 0)
                {
                    var child = node.Left;
                    RotateLeft(ref child);
                    node.Left = child;
                }
                RotateRight(ref node);
            }
        }
        private static void BalanceIfRightIsHeavy(ref AvlNode<T> node)
        {
            node.UpdateSizes();

            if (node.Balance < -1)
            {
                if (node.Right.Balance > 0)
                {
                    var child = node.Right;
                    RotateRight(ref child);
                    node.Right = child;
                }
                RotateLeft(ref node);
            }
        }

        private static void Rotate(ref AvlNode<T> root, int left, int right)
        {
            var newRoot = root.Children[left];
            root.Children[left] = newRoot.Children[right];
            newRoot.Children[right] = root;

            root.UpdateSizes();
            newRoot.UpdateSizes();

            root = newRoot;
        }

        private void UpdateSizes()
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + 1;
        }
    }
}
