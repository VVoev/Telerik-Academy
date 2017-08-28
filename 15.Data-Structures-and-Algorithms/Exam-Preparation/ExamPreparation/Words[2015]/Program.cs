using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Words_2015_
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberSuffix = 0;
            int numberPreffix = 0;
            var combinations = new List<int>();

            var contain = new List<int>();
            var word = Console.ReadLine();
            var sentence = Console.ReadLine();

            for (int i = 0; i < word.Length; i++)
            {
                var pre = word.Substring(0, i + 1);
                var suffix = word.Substring(i + 1);

                if (suffix != "")
                    numberSuffix = Regex.Matches(sentence, suffix).Count;
                numberPreffix = Regex.Matches(sentence, pre).Count;

                if(numberSuffix == 0 || numberPreffix == 0)
                    combinations.Add(numberSuffix + numberPreffix);
                if(numberPreffix > 0 && numberSuffix > 0)
                    combinations.Add(numberSuffix * numberPreffix);

                numberPreffix = 0;numberSuffix = 0;

            }
            Console.WriteLine(combinations.Sum());
        }
    }
}
