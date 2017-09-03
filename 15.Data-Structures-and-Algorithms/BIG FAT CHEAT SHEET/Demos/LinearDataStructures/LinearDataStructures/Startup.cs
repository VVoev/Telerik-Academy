using LinearDataStructures.DataStructures.Queue.DoubleEndedQueue;

namespace LinearDataStructures
{
    public class Startup
    {
        public static void Main()
        {
            var doubleEndedQueue = new DoubleEndedQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                doubleEndedQueue.PushBack(i);
            }

            for (int i = 0; i < 10; i++)
            {
                doubleEndedQueue.PushFront(i);
            }

            for (int i = 0; i < 3; i++)
            {
                doubleEndedQueue.PopFront();
                doubleEndedQueue.PopBack();
            }

            System.Console.WriteLine(string.Join(", ", doubleEndedQueue));
        }
    }
}
