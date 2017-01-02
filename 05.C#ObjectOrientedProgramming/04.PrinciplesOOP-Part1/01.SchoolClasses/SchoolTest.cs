namespace _01.SchoolClasses
{
    using Disciplines;
    using Persons;
    using Schools;
    using Schools.SchoolClasses;
    using System;
    using System.Collections.Generic;

    class SchoolTest
    {
        static void Main()
        {
         
            // Add disciplines.
            Discipline math = new Discipline(DisciplineEnum.Mathematics, 3, 4);
            Discipline biology = new Discipline(DisciplineEnum.Biology, 2, 2);
            Discipline sport = new Discipline(DisciplineEnum.Sport, 2, 3);
            Discipline chemistry = new Discipline(DisciplineEnum.Chemistry, 2, 2);
            Discipline literature = new Discipline(DisciplineEnum.Literature, 3, 3);
            Discipline physics = new Discipline(DisciplineEnum.Physics, 2, 2);
            Discipline accounting = new Discipline(DisciplineEnum.Accounting, 3, 3);

            // Add teachers.
            Teacher teacher1 = new Teacher("Mladen Mladenov", new List<Discipline>() { math, physics, sport });
            Teacher teacher2 = new Teacher("Emilia Angelova", new List<Discipline>() { literature, biology, accounting });
            Teacher teacher3 = new Teacher("Plamen Stoyanov", new List<Discipline>() { chemistry, physics });
            var teachers = new SortedSet<Teacher>() { teacher1, teacher2, teacher3 };

            // Add students.
            Student student1 = new Student("Alexander Vasilev", 1);
            Student student2 = new Student("Poli Hristova", 5);
            Student student3 = new Student("Gergana Strashimirova", 3);
            Student student4 = new Student("Anelia Neshkova", 2);
            Student student5 = new Student("Lubomir Petrov", 4);
            Student student6 = new Student("Vencislav Arnaudov", 6);
            var students = new SortedSet<Student>() { student1, student2, student3, student4, student5, student6 };

            // Add class to school.
            var currentClass = new SchoolClass(SchoolClassEnum.k4, students, teachers);
            var secondClass = new SchoolClass(SchoolClassEnum.k1, students, teachers);
            var thirdClass = new SchoolClass(SchoolClassEnum.t, students, teachers);
            // Add school.
            var nfsg = new School(new List<SchoolClass>() { thirdClass,currentClass, secondClass});

            Console.WriteLine(nfsg.ToString());
        }
    }
}