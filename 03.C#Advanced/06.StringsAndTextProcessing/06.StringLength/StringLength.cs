using System;
using System.Text;

class StringLength
{
    static void Main()
    {
        string text = Console.ReadLine();
        text = text.Replace(@"\", string.Empty);
        StringBuilder result = new StringBuilder();
       
        if (text.Length < 20)
        {
            result.Append(text.Substring(0,text.Length));
            result.Append('*', 20 - text.Length);
            Console.WriteLine(result.ToString());
        }
        else
        {
            Console.WriteLine(text.Substring(0,20));
        }
    }
}
