namespace _05.School
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class SchoolTest
    {
        static void Main()
        {
            var nfsg = new School();


            var disciplines = new List<Discipline>();
            var mathTeacher = new Teacher("Mladen Mladenov", disciplines);
            disciplines.Add(new Discipline("Algebra", 4, 3));
            disciplines.Add(new Discipline("Geometry", 3, 3));
            disciplines.Add(new Discipline("Physics", 2, 2));

            string studentName = Console.ReadLine();
            int i = 1;
            while (studentName != "end")
            {
                var currentStudent = new Student(studentName, i);
                i++;
                //nfsg.Students.Add
            }

        }
    }
}
