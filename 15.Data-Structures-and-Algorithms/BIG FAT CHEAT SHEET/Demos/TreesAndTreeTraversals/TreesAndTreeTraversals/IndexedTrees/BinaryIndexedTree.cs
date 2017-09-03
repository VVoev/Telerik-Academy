using System;
using System.Collections.Generic;

namespace TreesAndTreeTraversals.IndexedTrees
{
    public class BinaryIndexedTree<T>
    {
        private Func<T, T, T> combineFunc;
        private T[] tree;
        private int realN;

        public T[] Tree
        {
            get
            {
                return this.tree;
            }
        }

        public BinaryIndexedTree(int n, Func<T, T, T> f)
        {
            this.realN = 1;
            while (realN < n)
            {
                this.realN *= 2;
            }

            this.tree = new T[this.realN * 2];
            this.combineFunc = f;
        }

        public BinaryIndexedTree(T[] initial, Func<T, T, T> f)
            : this(initial.Length, f)
        {
            for (int i = 0; i < initial.Length; i++)
            {
                tree[this.realN + i] = initial[i];
            }

            for (int i = this.tree.Length - 1; i > 1; i--)
            {
                this.UpdateIndex(i);
            }
        }

        public BinaryIndexedTree(ICollection<T> initial, Func<T, T, T> f)
          : this(initial.Count, f)
        {
            int index = 0;
            foreach (var element in initial)
            {
                tree[this.realN + index] = element;
                ++index;
            }

            for (int i = this.tree.Length - 1; i > 1; i--)
            {
                this.UpdateIndex(i);
            }
        }

        public T this[int index]
        {
            get
            {
                return tree[this.realN + index];
            }

            set
            {
                int indexToUpdate = this.realN + index;
                tree[indexToUpdate] = value;

                while (indexToUpdate > 1)
                {
                    UpdateIndex(indexToUpdate);
                    indexToUpdate /= 2;
                }
            }

        }

        public T GetInterval(int left, int right)
        {
            return this.GetInterval(left, right, 1, 0, this.realN);
        }

        private T GetInterval(int leftQuery, int rightQuery, int index, int leftNode, int rightNode)
        {
            if (leftQuery == leftNode && rightQuery == rightNode)
            {
                return tree[index];
            }

            int middleNode = (leftNode + rightNode) / 2;

            if (rightQuery <= middleNode)
            {
                return this.GetInterval(leftQuery, rightQuery, index * 2, leftNode, middleNode);
            }

            if (leftQuery >= middleNode)
            {
                return this.GetInterval(leftQuery, rightQuery, index * 2 + 1, middleNode, rightNode);
            }

            return this.combineFunc(this.GetInterval(leftQuery, middleNode, index * 2, leftNode, middleNode),
                this.GetInterval(middleNode, rightQuery, index * 2 + 1, middleNode, rightNode));
        }

        private void UpdateIndex(int index)
        {
            this.tree[index / 2] = combineFunc(tree[index], tree[index ^ 1]);
        }
    }
}
