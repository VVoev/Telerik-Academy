namespace _01.ExtensionSubstring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class ExtensionTest
    {
        static void Main()
        {
            string input = "I am bad programmer";
            var substring = new StringBuilder();
            substring.Append(input);
            var result = substring.Substring(10, 5);
            Console.WriteLine(result);
        }
    }
}
