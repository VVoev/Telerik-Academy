namespace _01.BoolToString
{
    using System;
    
    public class BoolToStringProgram
    {
        public const int MaxCount = 6;

        public void ConvertBoolToString(bool value)
        {
            string boolAsString = value.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}
