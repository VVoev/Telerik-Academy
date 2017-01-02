namespace _03.StudentOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Students;
    using Students.ExtensionMethods;

    class StudentOperations
    {
        static void Main()
        {
            var studentsToOrder = new List<Student>();

            // Create some students.
            var firstStudent = new Student("Martin", "Georgiev", 24);
            var secondStudent = new Student("Plamena", "Ilieva", 22);
            var thirdStudent = new Student("Martina", "Georgieva", 16);
            var fourthStudent = new Student("Antoine", "Griezmann", 29);
            var fifthStudent = new Student("Nikoleta", "Borislavova", 31);

            // Add student to current list.
            studentsToOrder.Add(firstStudent);
            studentsToOrder.Add(secondStudent);
            studentsToOrder.Add(thirdStudent);
            studentsToOrder.Add(fourthStudent);
            studentsToOrder.Add(fifthStudent);

            // Problem 3.
            // Find students whose first name is before their last name.
            var sortedStudents = studentsToOrder.Where(x => x.FirstName.CompareTo(x.LastName) < 0)
                                                .ToList();
            Console.WriteLine("Problem 3 - Sorted by first and last name: \r\n" + string.Join(Environment.NewLine, sortedStudents));

            // Problem 4.
            // Find students whose age is between 18 and 24.
            var sortedStudentsByAge = studentsToOrder.Where(x => x.Age >= 18 && x.Age <= 24)
                                                     .ToList();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Problem 4 - Sorted by age: \r\n" + string.Join(Environment.NewLine, sortedStudentsByAge));

            // Problem 5.
            var sortedStudentsByLAMBDA = studentsToOrder.OrderByDescending(x => x.FirstName)
                                                                .ThenByDescending(x => x.LastName)
                                                                .ToList();
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Problem 5 - Sorted students using LAMBDA: \r\n" + string.Join(Environment.NewLine, sortedStudentsByLAMBDA));

            var sortedStudentsByLINQ = from student in studentsToOrder
                                       orderby student.FirstName descending,
                                           student.LastName descending
                                       select student;
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Problem 5 - Sorted students using LINQ: \r\n" + string.Join(Environment.NewLine, sortedStudentsByLINQ));

            // Problems from 9 to 19.
            StudentGroupTest.GroupTest();
        }
    }
}
