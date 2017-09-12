using System;

namespace AvlTreeIterative
{
    internal class AvlNode<T>
        where T : IComparable<T>
    {
        private int size;
        private int height;

        public T Value { get; private set; }

        public AvlNode<T>[] Neighbours { get; private set; }

        public AvlNode<T> Left
        {
            get
            {
                return this.Neighbours[0];
            }
            set
            {
                this.Neighbours[0] = value;
            }
        }
        public AvlNode<T> Right
        {
            get
            {
                return this.Neighbours[1];
            }
            set
            {
                this.Neighbours[1] = value;
            }
        }
        public AvlNode<T> Parent
        {
            get
            {
                return this.Neighbours[2];
            }
            set
            {
                this.Neighbours[2] = value;
            }
        }

        public AvlNode(T value)
        {
            this.size = 1;
            this.height = 1;
            this.Value = value;
            this.Neighbours = new AvlNode<T>[3];
        }

        public static int GetSize(AvlNode<T> node)
        {
            return node == null ? 0 : node.size;
        }

        public static int GetHeight(AvlNode<T> node)
        {
            return node == null ? 0 : node.height;
        }

        public int Balance => GetHeight(Left) - GetHeight(Right);

        private void UpdateSizes()
        {
            this.size = GetSize(this.Left) + GetSize(this.Right) + 1;
            this.height = Math.Max(GetHeight(this.Left), GetHeight(this.Right)) + 1;
        }

        public void Update()
        {
            var root = this;

            //var balance = this.Balance;
            //if (balance < -1)
            //{
            //    if (this.Right.Balance > 0)
            //    {
            //        this.Right.RotateRight();
            //    }
            //    root = this.RotateLeft();
            //}
            //else if (balance > 1)
            //{
            //    if (this.Left.Balance < 0)
            //    {
            //        this.Left.RotateLeft();
            //    }
            //    root = this.RotateRight();
            //}
            if(this.Right != null)
            {
                root = this.RotateLeft();
            }
            else
            {
                root.UpdateSizes();
            }

            if (root.Parent != null)
            {
                root.Parent.Update();
            }
        }

        public AvlNode<T> RotateRight()
        {
            return this.Rotate(0, 1);
        }

        public AvlNode<T> RotateLeft()
        {
            return this.Rotate(1, 0);
        }

        private AvlNode<T> Rotate(int left, int right)
        {
            var newRoot = this.Neighbours[left];

            if (newRoot.Neighbours[right] != null)
            {
                newRoot.Neighbours[right].Parent = this;
            }
            if (this.Parent != null)
            {
                if (this == this.Parent.Left)
                {
                    this.Parent.Left = newRoot;
                }
                else
                {
                    this.Parent.Right = newRoot;
                }
            }
            newRoot.Parent = this.Parent;
            this.Parent = newRoot;

            this.Neighbours[left] = newRoot.Neighbours[right];
            newRoot.Neighbours[right] = this;

            this.UpdateSizes();
            newRoot.UpdateSizes();

            return newRoot;
        }
    }
}
