using Exceptions_Homework.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

class ExceptionsHomework
{
    static void Main()
    {
        var substr = Utilities.Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(String.Join(" ", subarr));

        var allarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(String.Join(" ", allarr));

        var emptyarr = Utilities.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(String.Join(" ", emptyarr));

        Console.WriteLine(Utilities.ExtractEnding("I love C#", 2));
        Console.WriteLine(Utilities.ExtractEnding("Nakov", 4));
        Console.WriteLine(Utilities.ExtractEnding("beer", 4));
        Console.WriteLine(Utilities.ExtractEnding("Hi", 100));

        try
        {
            Utilities.CheckPrime(23);
            Console.WriteLine("23 is prime.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("23 is not prime");
        }

        try
        {
            Utilities.CheckPrime(33);
            Console.WriteLine("33 is prime.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
