namespace _03.StudentOperations.Students
{
    using System;
    using Students.ExtensionMethods;
    using System.Collections.Generic;
    using System.Linq;

    public class StudentGroupTest
    {
        public static void GroupTest()
        {
            var listOfStudentsUNWE = new List<Student>();
            Student worstStudent, goodStudent, topStudent, averageStudent;
            CreateStudents(out worstStudent, out goodStudent, out topStudent, out averageStudent);
            listOfStudentsUNWE.Add(worstStudent);
            listOfStudentsUNWE.Add(goodStudent);
            listOfStudentsUNWE.Add(topStudent);
            listOfStudentsUNWE.Add(averageStudent);

            // Problem 9.
            int group = 2;
            var studentsByGroup2 = listOfStudentsUNWE.OrderBy(x => x.FirstName)
                                                     .Where(x => x.Group == group)
                                                     .ToList();
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Problem 9 - Students in group {group}:");
            foreach (var student in studentsByGroup2)
            {
                Console.WriteLine(student.ToString() + " " + student.GroupNumber);
            }
            Console.WriteLine("--------------------------------");

            // Problem 10.
            var studentsByGroup = listOfStudentsUNWE.OrderByGroup(group)
                                                    .ThenByFirstName()
                                                    .ToList();
            Console.WriteLine($"Problem 10 - Students in group {group}:");
            foreach (var student in studentsByGroup)
            {
                Console.WriteLine(student.ToString() + " " + student.GroupNumber);
            }
            Console.WriteLine("--------------------------------");

            // Problem 11.
            string emailDomain = "abv.bg";
            var studentsWithEmail = listOfStudentsUNWE.ExtractByEmail(emailDomain)
                                                      .ToList();
            Console.WriteLine($"Problem 11 - Students with e-mail {emailDomain}:");
            foreach (var student in studentsWithEmail)
            {
                Console.WriteLine(student.ToString() + " " + student.E_Mail);
            }
            Console.WriteLine("--------------------------------");

            // Problem 12.
            string phonePrefix = "02";
            var studentsWithPhone = listOfStudentsUNWE.ExtractByPhone("02")
                                                      .ToList();
            Console.WriteLine($"Problem 12 - Students with phone from Sofia:");
            foreach (var student in studentsWithPhone)
            {
                Console.WriteLine(student.ToString() + " " + student.PhoneNumber);
            }
            Console.WriteLine("--------------------------------");

            //Problem 13.
            double mark = 5;
            var studentsWithOneExcellentMark = listOfStudentsUNWE.Where(x => x.Marks.Contains(mark))
                                                                 .Select(
                                                                  x => new
                                                                  {
                                                                      FullName = x.FirstName + " " + x.LastName,
                                                                      Marks = x.Marks
                                                                  })
                                                                 .ToList();
            Console.WriteLine($"Problem 13 - Students with at least one mark ({mark}):");
            foreach (var student in studentsWithOneExcellentMark)
            {
                Console.WriteLine(student.FullName);
                Console.WriteLine("- " + string.Join(", ", student.Marks));
            }
            Console.WriteLine("--------------------------------");

            //Problem 14.
            int numberOfMarks = 6;
            var studentsWithNumberOfMarks = listOfStudentsUNWE.ExtractByMarkLength(numberOfMarks)
                                                              .ToList();
            Console.WriteLine($"Problem 14 - Students with number of marks ({numberOfMarks})");

            foreach (var student in studentsWithNumberOfMarks)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine("- " + string.Join(", ", student.Marks));
            }
            Console.WriteLine("--------------------------------");

            // Problem 15.
            string year = "06";
            var studentsByYearOfMarks = listOfStudentsUNWE.ExtractByYearOfMarks(year)
                                                          .ToList();
            Console.WriteLine($"Problem 15 - Students with same year of marks ({year})");

            foreach (var student in studentsByYearOfMarks)
            {
                Console.WriteLine(student.ToString());
                Console.WriteLine("- " + string.Join(", ", student.Marks));
            }
            Console.WriteLine("--------------------------------");

            // Problem 16.
            string discipline = "Mathematics";
            var studentsByDepartment = listOfStudentsUNWE.Where(x => x.GroupNumber.DepartmentName
                                                                      .CompareTo(discipline) == 0)
                                                         .Select(x =>  new { FullName = x.ToString(),})
                                                         .ToList();

            Console.WriteLine($"Problem 16 - Students with same discipline ({discipline})");

            foreach (var student in studentsByDepartment)
            {
                Console.WriteLine(student.FullName);
            }
            Console.WriteLine("--------------------------------");

            // Problem 17.
            var longestString = listOfStudentsUNWE.Max(x => x.ToString());
            Console.WriteLine($"Problem 17 - longest string is {longestString} with {longestString.Length} characters.");

            // Problem 18.
            var studentsByGroupNumber = listOfStudentsUNWE.ExtractInGroups();
            Console.WriteLine($"Problem 18 - Students extracted by group number.");

            foreach (var groupNum in studentsByGroupNumber)
            {
                Console.WriteLine("Group " + groupNum.Key);
                foreach (var student in groupNum)
                {
                    Console.WriteLine("- " + string.Join(Environment.NewLine, student.ToString()));
                }
            }
            Console.WriteLine("--------------------------------");

            // Problem 19. 
            var studentsByGroupName = listOfStudentsUNWE.GroupBy(x => x.GroupNumber.DepartmentName,
                                                         (x, y) => new
                                                         {
                                                             GroupNumber = x,
                                                             Students = y,
                                                         })
                                                 .ToList();
            Console.WriteLine($"Problem 19 - Students extracted by group name.");
            foreach (var groupName in studentsByGroupName)
            {
                Console.WriteLine("Group " + groupName.GroupNumber);
                Console.WriteLine("- " + string.Join(", ", groupName.Students));
            }
        }

        private static void CreateStudents(out Student worstStudent, out Student goodStudent, out Student topStudent, out Student averageStudent)
        {
            var groupInfo1 = new Group("Mathematics", 1);
            var groupInfo2 = new Group("Physics", 2);
            var groupInfo3 = new Group("Economics", 3);
            var groupInfo4 = new Group("Macroeconomics", 4);

            worstStudent = new Student(
                "Alexander",
                "Vasilev",
                "1122069",
                "0888666333",
                "vasilev.alexander@gmail.com",
                new List<double>() { 4.5, 5.5, 6, 3, 4.44, 5.43 },
                1,
                groupInfo1);

            goodStudent = new Student(
                "Milena",
                "Georgieva",
                "11220419",
                "0888636363",
                "georgieva.milena@gmail.com",
                new List<double>() { 4.15, 5.5, 5.25, 5, 4.74, 5.13 },
                2,
                groupInfo1);

            topStudent = new Student(
                "Asen",
                "Petrov",
                "11220629",
                "0888999030",
                "petrov.qsen@gmail.com",
                new List<double>() { 5.95, 5.85, 6, 6, 5.84, 5.73 },
                2,
                groupInfo2);

            averageStudent = new Student(
                "Natalia",
                "Bojanova",
                "1122042",
                "0888555111",
                "bojanova.natalia@yahoo.com",
                new List<double>() { 4.5, 5.5, 5.25, 5, 5.14, 4.43 },
                3,
                groupInfo3);
        }
    }
}
