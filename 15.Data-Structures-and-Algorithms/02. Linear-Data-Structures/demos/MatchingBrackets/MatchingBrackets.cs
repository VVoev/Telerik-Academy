namespace MatchingBrackets
{
    using System;
    using System.Collections.Generic;

    public static class MatchingBrackets
    {
        public static void Main()
        {
            var expression = "1 + (2 - (2+3) * 4 / (3+1)) * 5";
            var stack = new Stack<int>();

            for (int index = 0; index < expression.Length; index++)
            {
                char ch = expression[index];
                if (ch == '(')
                {
                    stack.Push(index);
                }
                else if (ch == ')')
                {
                    int startIndex = stack.Pop();
                    int length = index - startIndex + 1;
                    string contents = expression.Substring(startIndex, length);
                    Console.WriteLine(contents);
                }
            }
        }
    }
}
