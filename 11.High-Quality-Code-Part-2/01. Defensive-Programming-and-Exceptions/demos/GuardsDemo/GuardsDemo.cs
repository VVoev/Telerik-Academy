using Bytes2you.Validation;
using System.Collections;
using System.Collections.Generic;

namespace GuardsDemo
{
    class GuardsDemo
    {
        static void Main(string[] args)
        {

            string[] invalidArgs = new string[] { };


            var studentsData = new string[]
            {
                "Moncho tigurcheto_moni@yahoo.com 13",
                "Mimi mimi@yahoo.com 14",
                "Sashko sasheto@yahoo.com 13"
            };

            var students = ParseStudent(studentsData);

            students.ForEach(student =>
            {
                System.Console.WriteLine(student);
            });

            var sum = Sum(1, 2);
            System.Console.WriteLine(sum);

             sum = Sum(584958495, 2);
            System.Console.WriteLine(sum);

             sum = Sum(0, int.MaxValue/2+1);
            System.Console.WriteLine(sum);

             sum = Sum(-100, int.MinValue);
            System.Console.WriteLine(sum);



        }


        public static IEnumerable<Student> ParseStudent(string[] dataStudents)
        {

            Guard.WhenArgument(dataStudents, "studentsData").IsNullOrEmpty().Throw();

            var students = new List<Student>(dataStudents.Length);
            foreach (var data in dataStudents)
            {
                var studentDataArgs = data.Split(' ');
                var student = new Student
                {
                    Name = studentDataArgs[0],
                    Email = studentDataArgs[1],
                    Age = int.Parse(studentDataArgs[2])
                };

                students.Add(student);
            }

     

            return students;
        }



        public static int Sum(int a, int b)
        {
            var maxAllowed = int.MaxValue / 2;
            var minAllowed = 0;

            Guard.WhenArgument(a, "A").IsLessThan(minAllowed).IsGreaterThan(maxAllowed).Throw();
            Guard.WhenArgument(b, "B").IsLessThan(minAllowed).IsGreaterThan(maxAllowed).Throw();

            return a + b;
        }
    }
}
