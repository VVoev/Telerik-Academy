namespace _02.Generics

{
    using System;

    public class GenericsTest
    {
        static void Main()
        {
            var list = new GenericList<int>();

            for (int i = 0; i <= 10; i++)
            {
                list.Add(i * 3);
            }
            list.InsertAt(0,1);
            int indexAt = list.IndexAt(6);
            int indexOf = list.IndexOf(15);
            list.RemoveAt(8);
            list.Min();
            list.Max();
            Console.WriteLine("Max value: " + list.Max());
            Console.WriteLine("Min value: " + list.Min());
            Console.WriteLine("Index of: " + indexOf);
            Console.WriteLine("Index at: " + indexAt);
            Console.WriteLine("Override method ToString: " + list.ToString());

            list.Clear();
            Console.WriteLine("Elements in GenericList after clear: " + list.Count);
        }
    }
}
