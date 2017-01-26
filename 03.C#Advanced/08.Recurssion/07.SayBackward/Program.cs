using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.SayBackward
{
    class Program
    {
        static void Main(string[] args)
        {
            var sentence = "\nHello i love recurssion and this is why i am using it everywhere";
            SayBack(sentence,-1);
        }

        private static char SayBack(string sentence,int index)
        {
            if (index == sentence.Length - 1)
            {
                return sentence[index];
            }
            else
            {
                Console.Write($"{SayBack(sentence,index+1)}");
                if (index < 0)
                    return 'a';
                    return sentence[index];
            }
        }
    }
}
