namespace KnuthMorisPrat
{
    public class Startup
    {
        public static void Main()
        {
            string pattern = "alabala";

            var failLink = PrecomputeKMP(pattern);
            System.Console.WriteLine(string.Join(" ", failLink));

            string text = "xalabalabalaalabala";

            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                while (j >= 0 &&pattern[j] != text[i])
                {
                    j = failLink[j];
                }

                j += 1;

                if (j == pattern.Length)
                {
                    PrintMatch(i - pattern.Length + 1, pattern);
                    j = failLink[j];
                }
            }
        }

        public static int[] PrecomputeKMP(string text)
        {
            var failLink = new int[text.Length + 1];

            failLink[0] = -1;
            failLink[1] = 0;

            for (int i = 1; i < text.Length; i++)
            {
                int j = failLink[i];

                while (j >= 0 && text[j] != text[i])
                {
                    j = failLink[j];
                }

                failLink[i + 1] = j + 1;
            }

            return failLink;
        }

        public static void PrintMatch(int index, string match)
        {
            for (int i = 0; i < index; i++)
            {
                System.Console.Write(" ");
            }

            System.Console.WriteLine(match);
        }
    }
}
