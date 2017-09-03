    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace _03.NoDescription
    {
        public class Program
        {
            public static string ToRoman(int number)
            {
                if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
                if (number < 1) return string.Empty;
                if (number >= 1000) return "M" + ToRoman(number - 1000);
                if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
                if (number >= 500) return "D" + ToRoman(number - 500);
                if (number >= 400) return "CD" + ToRoman(number - 400);
                if (number >= 100) return "C" + ToRoman(number - 100);
                if (number >= 90) return "XC" + ToRoman(number - 90);
                if (number >= 50) return "L" + ToRoman(number - 50);
                if (number >= 40) return "XL" + ToRoman(number - 40);
                if (number >= 10) return "X" + ToRoman(number - 10);
                if (number >= 9) return "IX" + ToRoman(number - 9);
                if (number >= 5) return "V" + ToRoman(number - 5);
                if (number >= 4) return "IV" + ToRoman(number - 4);
                if (number >= 1) return "I" + ToRoman(number - 1);
                throw new ArgumentOutOfRangeException("something bad happened");
            }

            public static void Main()
            {
                int number = int.Parse(Console.ReadLine());

                var roman = ToRoman(number);

                var result = new StringBuilder();

                for (int i =0; i < roman.Length; i++)
                {
                    switch (roman[i])
                    {
                        case 'I': result.Append("0");
                            break;
                        case 'V': result.Append("1"); 
                            break;
                        case 'X': result.Append("2");
                            break;
                        case 'L': result.Append("3");
                                break;
                        case 'C': result.Append("4");
                            break;
                        case 'D': result.Append("5");
                            break;
                        case 'M': result.Append("6");
                            break;
                    }
                }

                Console.WriteLine(result.ToString().Trim());
            }
        }
    }
