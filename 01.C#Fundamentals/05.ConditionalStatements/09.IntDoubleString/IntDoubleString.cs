using System;

class IntDoubleString
{
    static void Main()
    {
        string type = Console.ReadLine();
        
        if (type == "real")
        {
            double number = double.Parse(Console.ReadLine());
            Console.WriteLine("{0:F2}",++number);
        }
        else if (type == "integer")
        {
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(++number);
        }
        else if (type == "text")
        {
            string result = Console.ReadLine();
            Console.WriteLine("{0}*", result);
        }
    }
}
