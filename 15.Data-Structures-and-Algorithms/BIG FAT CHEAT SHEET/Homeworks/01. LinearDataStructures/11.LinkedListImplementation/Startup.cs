using System;

namespace _11.LinkedListImplementation
{
    public class Startup
    {
        public static void Main()
        {
            var list = new System.Collections.Generic.LinkedList<int>();
            var myList = new LinkedList<int>();

            for (int i = 0; i < 15; i++)
            {
                list.AddLast(i);
                myList.AddLast(i);
            }


            list.Remove(14);
            myList.Remove(14);

            Console.WriteLine(string.Join(", ", list));
            Console.WriteLine(string.Join(", ", myList));
        }
    }
}
