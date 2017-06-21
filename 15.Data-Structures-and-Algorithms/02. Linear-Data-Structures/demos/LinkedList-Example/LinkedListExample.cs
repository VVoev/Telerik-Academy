namespace LinkedList_Example
{
    using System;
    using System.Collections.Generic;

    public static class LinkedListExample
    {
        public static void Main()
        {
            var linkedList = new LinkedList<string>();
            linkedList.AddFirst("First");
            linkedList.AddLast("Last");
            linkedList.AddAfter(linkedList.First, "After First");
            linkedList.AddBefore(linkedList.Last, "Before Last");

            Console.WriteLine(string.Join(", ", linkedList));

            // Result: First, After First, Before Last, Last
        }
    }
}
