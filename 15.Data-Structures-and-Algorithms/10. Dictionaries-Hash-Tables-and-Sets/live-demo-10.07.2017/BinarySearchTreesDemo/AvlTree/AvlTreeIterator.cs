using System;

namespace AvlTreeIterative
{
    public class AvlTreeIterator<T>
        where T : IComparable<T>
    {
        internal AvlNode<T> Node { get; private set; }

        internal AvlTreeIterator(AvlNode<T> node)
        {
            this.Node = node;
        }

        public T Value => Node.Value;

        public void MoveRight()
        {
            this.Move(0, 1);
        }

        public void MoveLeft()
        {
            this.Move(1, 0);
        }

        private void Move(int left, int right)
        {
            if(Node.Neighbours[right] != null)
            {
                Node = Node.Neighbours[right];
                while(Node.Neighbours[left] != null)
                {
                    Node = Node.Neighbours[left];
                }
            }
            else
            {
                while(Node.Parent != null && Node.Parent.Neighbours[right] == Node)
                {
                    Node = Node.Parent;
                }
                if (Node.Parent == null) // Make this better
                {
                    Node = null;
                    return;
                }
                Node = Node.Parent;
            }
        }
    }
}
