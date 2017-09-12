namespace Queue
{
    public class QueueWithSinglyLinkedList<T>
    {
        private class Node
        {
            public T Value { get; set; }
            public Node Next { get; set; }
        }

        private Node head;
        private Node tail;

        public QueueWithSinglyLinkedList()
        {
            head = null;
            tail = null;
        }

        public T Front => head.Value;
        public bool Empty => head == null;

        public void Push(T value)
        {
            var newNode = new Node();
            newNode.Value = value;
            newNode.Next = null;

            if(tail != null)
            {
                tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
        }

        public bool Pop()
        {
            if (head != null)
            {
                head = head.Next;
                if(head == null)
                {
                    tail = null; 
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            head = null;
            tail = null;
        }
    }
}
