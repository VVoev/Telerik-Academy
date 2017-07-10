using System;
using System.Collections.Generic;

namespace IndexedTrees
{
    public class BinaryIndexedTree<T>
    {
        private Func<T, T, T> combineFunc;

        private T[] tree;

        private int realN;

        public BinaryIndexedTree(int n, Func<T, T, T> func)
        {
            realN = 1;
            while (realN < n)
            {
                realN *= 2;
            }

            tree = new T[realN * 2];

            combineFunc = func;
        }

        public BinaryIndexedTree(T[] initial, Func<T, T, T> func)
            : this(initial.Length, func)
        {
            for(int i = 0; i < initial.Length; ++i)
            {
                tree[realN + i] = initial[i];
            }

            for (int i = realN - 1; i > 1; --i)
            {
                Update(i);
            }
        }

        public BinaryIndexedTree(ICollection<T> initial, Func<T, T, T> func)
            : this(initial.Count, func)
        {
            int index = realN;
            foreach (var x in initial)
            {
                tree[index] = x;
                ++index;
            }

            for (int i = realN - 1; i > 1; --i)
            {
                Update(i);
            }
        }

        public T this[int index]
        {
            get
            {
                return tree[realN + index];
            }
            set
            {
                int indexToUpdate = realN + index;
                tree[indexToUpdate] = value;
                while (indexToUpdate > 1)
                {
                    Update(indexToUpdate);
                    indexToUpdate /= 2;
                }
            }
        }

        public T GetInterval(int left, int right)
        {
            return GetInterval(left, right, 1, 0, realN);
        }

        private T GetInterval(int leftQuery, int rightQuery, int index, int leftNode, int rightNode)
        {
            if(leftQuery == leftNode && rightQuery == rightNode)
            {
                return tree[index];
            }

            int middleNode = (leftNode + rightNode) / 2;


            if (rightQuery <= middleNode)
            {
                return GetInterval(leftQuery, rightQuery, index * 2, leftNode, middleNode);
            }

            if(leftQuery >= middleNode)
            {
                return GetInterval(leftQuery, rightQuery, index * 2 + 1, middleNode, rightNode);
            }

            return combineFunc(
                GetInterval(leftQuery, middleNode, index * 2, leftNode, middleNode),
                GetInterval(middleNode, rightQuery, index * 2 + 1, middleNode, rightNode));
        }

        private void Update(int index)
        {
            tree[index / 2] = combineFunc(tree[index], tree[index ^ 1]);
        }
    }
}
