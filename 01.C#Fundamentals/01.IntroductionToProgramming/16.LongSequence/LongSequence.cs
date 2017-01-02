using System;

class LongSequence
{
    static void Main()
    {
        int firstMember = 0;
        int secondMember = -1;
        for (int i = 0; i < 500; i++)
        {
            firstMember += 2;
            secondMember -= 2;
            Console.WriteLine(firstMember);
            Console.WriteLine(secondMember);
        }
    }
}
