using System;

class SubstringInText
{
    static void Main()
    {
        string match = Console.ReadLine().ToLower();
        string randomText = Console.ReadLine().ToLower();
        int count = 0;
        for (int i = 0; i <= randomText.Length - match.Length; i++)
        {
            string part = randomText.Substring(i, match.Length);
            if (part.Equals(match))
            {
                count++;
            }
        }
        Console.WriteLine(count);
    }
}
