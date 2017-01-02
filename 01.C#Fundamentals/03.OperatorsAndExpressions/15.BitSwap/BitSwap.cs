using System;

class BitSwap
{
    static void Main()
    {
        // Input data and variables.
        uint n = uint.Parse(Console.ReadLine());
        int p1 = int.Parse(Console.ReadLine());
        int p2 = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        uint resultP1;
        uint resultP2;
        // Main Logic.
        for (int i = 0; i < k; i++, p2++, p1++)
        {
            // Find bit at position p1 
            uint mask = (uint)1 << p1;
            resultP1 = (n & mask) >> p1;

            // Find bit at position p2
            mask = (uint)1 << p2;
            resultP2 = (n & mask) >> p2;
            // Replace bit at position p1
            if (resultP1 == 0)
            {
                mask = ~((uint)1 << p2);
                n = n & mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            else if (resultP1 == 1)
            {
                mask = (uint)1 << p2;
                n = n | mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            // Replace bit at position p2
            if (resultP2 == 0)
            {
                mask = ~((uint)1 << p1);
                n = n & mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
            else if (resultP2 == 1)
            {
                mask = (uint)1 << p1;
                n = n | mask;
                //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
            }
        }
        // Print the result after all bit replacements.
        Console.WriteLine(n);
        //Console.WriteLine(Convert.ToString(n, 2).PadLeft(32, '0'));
    }
}
