namespace LinearDataStructures.DataStructures.Stack
{
    public class Stack<T>
    {
        private StackItem<T> top;
        private int elementsCount;

        public Stack()
        {
            this.top = null;
            this.elementsCount = 0;
        }

        public bool IsEmpty
        {
            get
            {
                return this.elementsCount == 0;
            }
        }

        public int Count
        {
            get
            {
                return this.elementsCount;
            }
        }

        public void Push(T value)
        {
            var newNode = new StackItem<T>(value);
            if (this.top == null)
            {
                this.top = newNode;
            }

            newNode.Prev = top;
            this.top = newNode;
            this.elementsCount++;
        }

        public T Pop()
        {
            var poppedItem = this.top;
            this.top = this.top.Prev;

            this.elementsCount--;
            return poppedItem.Value;
        }

        public T Peek()
        {
            return this.top.Value;
        }
    }
}
