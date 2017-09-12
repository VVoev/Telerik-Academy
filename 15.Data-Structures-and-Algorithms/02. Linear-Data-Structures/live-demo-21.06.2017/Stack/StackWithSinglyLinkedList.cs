using Helpers;

namespace Stack
{
    public class StackWithSinglyLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node top;

        public StackWithSinglyLinkedList()
        {
            top = null;
        }

        public Optional<T> Top => top == null
            ? new Optional<T>()
            : new Optional<T>(top.Value);

        public void Push(T value)
        {
            var newNode = new Node();
            newNode.Value = value;
            newNode.Next = top;
            top = newNode;
        }

        public bool Pop()
        {
            if (top != null)
            {
                top = top.Next;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            top = null;
        }
    }
}
