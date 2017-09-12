namespace LinkedList
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedList()
        {
            First = null;
            Last = null;
            Size = 0;
        }

        public int Size { get; private set; }

        public DoublyLinkedNode<T> First { get; private set; }
        public DoublyLinkedNode<T> Last { get; private set; }

        public void PushFront(T value)
        {
            if (First == null)
            {
                ++Size;
                First = Last = new DoublyLinkedNode<T>(value);
                return;
            }
            InsertBefore(First, value);
        }

        public void PushBack(T value)
        {
            if (Last == null)
            {
                ++Size;
                First = Last = new DoublyLinkedNode<T>(value);
                return;
            }
            InsertAfter(Last, value);
        }

        public void InsertBefore(DoublyLinkedNode<T> node, T value)
        {
            ++Size;

            var newNode = new DoublyLinkedNode<T>(value);
            newNode.Next = node;
            newNode.Prev = node.Prev;

            newNode.Next.Prev = newNode;
            if (newNode.Prev != null)
            {
                newNode.Prev.Next = newNode;
            }
            else
            {
                First = newNode;
            }
        }
        public void InsertAfter(DoublyLinkedNode<T> node, T value)
        {
            ++Size;

            var newNode = new DoublyLinkedNode<T>(value);
            newNode.Prev = node;
            newNode.Next = node.Next;

            newNode.Prev.Next = newNode;
            if (newNode.Next != null)
            {
                newNode.Next.Prev = newNode;
            }
            else
            {
                Last = newNode;
            }
        }

        public void PopFront()
        {
            Remove(First);
        }

        public void PopBack()
        {
            Remove(Last);
        }

        public void Remove(DoublyLinkedNode<T> node)
        {
            --Size;

            if (node.Prev != null)
            {
                node.Prev.Next = node.Next;
            }
            else
            {
                First = node.Next;
            }

            if (node.Next != null)
            {
                node.Next.Prev = node.Prev;
            }
            else
            {
                Last = node.Prev;
            }
        }
    }
}
