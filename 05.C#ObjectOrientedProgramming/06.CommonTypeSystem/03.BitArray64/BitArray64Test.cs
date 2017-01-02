namespace _03.BitArray64
{
    using System;

    class BitArray64Test
    {
        static void Main()
        {
            Random number = new Random();
            var bitNumber = number.Next(0, int.MaxValue);
            Console.WriteLine(bitNumber);
            var arr = new BitArray64((ulong)bitNumber);
            Console.WriteLine(arr);
            Console.WriteLine(arr[5]);
        }
    }
}
