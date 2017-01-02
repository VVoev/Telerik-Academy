namespace _02.StudentsAndWorkers
{
    using AbstractClass;
    using Extensions;
    using People;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StudentsAndWorkersTest
    {
        static void Main()
        {
            // Create 10 students.
            var student1 = new Student("Asen", "Parvanova", 6);
            var student2 = new Student("Viktoria", "Angelova", 8);
            var student3 = new Student("Plamena", "Stoyanova", 8);
            var student4 = new Student("Plamen", "Stoyanov", 12);
            var student5 = new Student("Alexander", "Stoyanov", 11);
            var student6 = new Student("Asen", "Cvetanov", 4);
            var student7 = new Student("Petar", "Dimitrov", 9);
            var student8 = new Student("Vladimir", "Neshev", 3);
            var student9 = new Student("Plamen", "Stoykov", 8);
            var student10 = new Student("Evgeni", "Parvanov", 10);

            // Add students to List.
            var listOfStudents = new List<Student>()
            {
                student1 ,
                student2 ,
                student3 ,
                student4 ,
                student5 ,
                student6 ,
                student7 ,
                student8 ,
                student9 ,
                student10,
            };

            // Create 10 workers.
            var worker1 = new Worker("Asen", "Parvanova", 100, 6);
            var worker2 = new Worker("Viktoria", "Anastasova", 245.11m, 8);
            var worker3 = new Worker("Plamena", "Todorova", 325.88m, 8);
            var worker4 = new Worker("Plamen", "Vasilev", 350m, 7);
            var worker5 = new Worker("Aleksandar", "Stoyanov", 198.99m, 6);
            var worker6 = new Worker("Nikola", "Cvetanov", 345.11m, 8);
            var worker7 = new Worker("Borislav", "Dimitrov", 300m, 7);
            var worker8 = new Worker("Velislava", "Neshev", 290m, 6);
            var worker9 = new Worker("Plamena", "Stoykova", 430m, 8);
            var worker10 = new Worker("Evgenia", "Parvanova", 445m, 8);

            // Add workers to List.
            var listOfWorkers = new List<Worker>()
            {
                worker1 ,
                worker2 ,
                worker3 ,
                worker4 ,
                worker5 ,
                worker6 ,
                worker7 ,
                worker8 ,
                worker9 ,
                worker10,
            };

            // Order students by grade ascending using Extension method.
            Console.WriteLine("Order students by grade ascending:");
            var orderedStudents = listOfStudents.OrderByGrade()
                                                .ToList();
            orderedStudents.ForEach(x => Console.WriteLine(" - " + x.ToString()));
            Console.WriteLine("-------------------------------");

            // Order workers by money per hour descending using Extension method.
            Console.WriteLine("Order students by amount per hour descending:");
            var orderedWorkers = listOfWorkers.OrderByMoneyPerHour()
                                              .ToList();
            orderedWorkers.ForEach(x => Console.WriteLine(" - " + x.ToString()));
            Console.WriteLine("-------------------------------");

            // Merge all humans in one list and sort them by first and last name.
            Console.WriteLine("Merged list of workers and students:");
            var mergedList = new List<Human>();
            mergedList.AddRange(listOfStudents.Take(listOfStudents.Count));
            mergedList.AddRange(listOfWorkers.Take(listOfWorkers.Count));
            var sortedMergeList = mergedList.OrderBy(x => x.FirstName).ToList();
            sortedMergeList.ForEach(x => Console.WriteLine(" - " + x.FullName));
        }
    }
}
