namespace _03.StudentInformation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StudentTest
    {
       public static void TestStudents()
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> studentsInUNWE = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string name = Console.ReadLine(); //"Alexander Georgiev Nestorov "; 
                string[] names = name.Split(' ');
                string firstName = names[0];
                string surName = names[1];
                string lastName = names[2];
                string speciality = Console.ReadLine(); //"Financial management";
                string university = Console.ReadLine(); //"University of National and World Economy"; 
                Student currentStudent = new Student(name, Course.fourth, speciality, university);
                //currentStudent.FirstName = firstName;
                studentsInUNWE.Add(currentStudent);
            }
            var sortedStudentsByFirstName = studentsInUNWE.OrderBy(x => x.FullName)
                                                          .Where(x => x.Speciality != "Finance")
                                                          .ToList();

            Console.WriteLine("-----------------------------");
            Console.WriteLine(string.Join(Environment.NewLine, sortedStudentsByFirstName));
        }
    }
}
