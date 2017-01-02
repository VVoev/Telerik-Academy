namespace _01.ExtensionSubstring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class StringBuilderExtension
    {
        public static StringBuilder Substring(this StringBuilder input, int index, int length)
        {
            var substring = new StringBuilder();
            if (index < 0 || index > input.Length)
            {
                throw new IndexOutOfRangeException("Starting index is outside the length of current StringBuilder.");
            }
            else if (index + length > input.Length || length <= 0)
            {
                throw new IndexOutOfRangeException("Length of substring is bigger than the length of current StringBuilder.");
            }
            else
            {
                for (int i = index; i < index + length; i++)
                {
                    substring.Append(input[i]);
                }
            }
            return substring;
        }
    }
}
