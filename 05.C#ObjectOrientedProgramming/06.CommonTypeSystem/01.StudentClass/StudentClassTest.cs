namespace _01.StudentClass
{
    using System;
    using System.Collections.Generic;

    class StudentClassTest
    {
        static void Main()
        {
            var firstStudent = new Student("Ivan", "Angelov", "Georgiev", "112987643");
            var secondStudent = new Student("Tania", "Qneva", "Popova", "112987643");
            var equalToSecondStudent = new Student("Ivan", "Angelov", "Georgiev","212987643");
            var thirdStudent = new Student("Stoyan", "Petrov", "Petkov", "112789346");

            // Get Unique Hashcode.
            var listOfStudents = new List<Student>() { firstStudent, secondStudent, equalToSecondStudent, thirdStudent };
            listOfStudents.ForEach(x => Console.WriteLine(string.Format(x.FirstName + " " + 
                                                                        x.MiddleName + " " + 
                                                                        x.LastName + " " + 
                                                                        x.GetHashCode())));

            // Test equal override implementation.
            for (int i = 0; i < listOfStudents.Count; i++)
            {
                string studentNumber = "112789346";
                bool equalStudents = Student.Equals(listOfStudents[i].SSN,studentNumber);
                Console.WriteLine("Students equalty: "  + equalStudents);
            }

            // Override ToString implementation.
            listOfStudents.ForEach(x => Console.WriteLine(x.ToString()));

            // Clone method test.
            var cloneStudent = firstStudent.Clone().ToString();

            // Operators == and !=.
            Console.WriteLine("Test predefined operators == and !=");
            Console.WriteLine(firstStudent == secondStudent);
            Console.WriteLine(firstStudent != secondStudent);

            // Compare students and order them.
            Console.WriteLine("Comparing students.");
            var comparer = firstStudent.CompareTo(secondStudent);
            if (comparer == 0)
            {
                Console.WriteLine("Students aren't equal.");
            }
            else
            {
                Console.WriteLine("Students are equal.");
            }
        }
    }
}
