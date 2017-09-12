using ListDataStructure;

namespace Stack
{
    public class StackWithList<T>
    {
        private List<T> list;

        public StackWithList()
        {
            list = new List<T>();
        }

        public void Push(T value)
        {
            list.PushBack(value);
        }

        public void Pop()
        {
            list.PopBack();
        }

        public T Peek()
        {
            return list.Last;
        }

        public T Top => list.Last;

        public void Reserve(int size)
        {
            list.Reserve(size);
        }

        public void ShrinkToFit()
        {
            list.ShrinkToFit();
        }

        public int Size => list.Size;

        public bool Empty => list.Size == 0;
    }
}
