using System;

class SayHello
{
    static void Main()
    {
        string name = Console.ReadLine();
        PrintHello(name);
    }
    static void PrintHello(string userName)
    {
        Console.WriteLine("Hello, {0}!", userName);
    }
}
