using System;

class ReverseString
{
    static void Main()
    {
        string word = Console.ReadLine();
        char[] reverseWord = word.ToCharArray();
        Array.Reverse(reverseWord);
        Console.WriteLine(string.Join("", reverseWord));
    }
}
