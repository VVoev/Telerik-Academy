using System;

class CorrectBrackets
{
    static void Main()
    {
        string mathExpression = Console.ReadLine();
        int count = 0;
        for (int i = 0; i < mathExpression.Length; i++)
        {
            count = CheckForOpeningAndClosedBrackets(mathExpression, count, i);
            // If there is a closing bracket before an opening the expression is wrong.
            if (count < 0)
            {
               break;
            }
        }
        // If all brackets are correctly closed count must be zero.
        // In all other cases the expression is wrong.
        if (count == 0)
        {
            Console.WriteLine("Correct");
        }
        else
        {
            Console.WriteLine("Incorrect");
        }
    }

    private static int CheckForOpeningAndClosedBrackets(string mathExpression, int count, int i)
    {
        if (mathExpression[i].Equals('('))
        {
            count++;
        }
        else if (mathExpression[i].Equals(')'))
        {
            count--;
        }

        return count;
    }
}
