using System;
using System.Text;

class PrintTheASCIITable
{
    static void Main()
    {
        //Console.OutputEncoding = Encoding.GetEncoding(1252);
        for (int i = 33; i < 127; i++)
        {
            char symbol = (char)i;
            Console.Write("{0}", symbol);
        }
        Console.WriteLine();
    }
}
