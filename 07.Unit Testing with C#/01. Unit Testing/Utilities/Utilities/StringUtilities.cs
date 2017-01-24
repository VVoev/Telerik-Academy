namespace Utilities
{
    using System.Text.RegularExpressions;

    public class StringUtilities
    {
        public bool ValidateString(string input,string pattern)
        {
            var math = Regex.Match(input, pattern);
            return math.Success;
        }
    }
}
