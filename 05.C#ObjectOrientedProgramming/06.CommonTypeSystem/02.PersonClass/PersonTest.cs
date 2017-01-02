namespace _02.PersonClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class PersonTest
    {
        static void Main()
        {
            var person1 = new Person("Angel Vasilev Trifonov", 22);
            var person2 = new Person("Georgi Nikolov Anastasov", 30);
            var person3 = new Person("Borislav Evgeniev Asenov");
            var person4 = new Person("Angelina Petrova Atanasova");

            var listOfPersons = new List<Person>() { person1, person2, person3, person4 };
            listOfPersons.ForEach(x => Console.WriteLine(x.ToString()));
        }
    }
}
