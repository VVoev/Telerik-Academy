using System;
using System.Collections.Generic;

namespace _2.Composite
{
    class Commander : PersonComponent
    {
        private readonly ICollection<PersonComponent> persons;

        public Commander(string name) : base(name)
        {
            this.persons = new List<PersonComponent>();
        }

        public void Add(PersonComponent person)
        {
            this.persons.Add(person);
        }

        public void Remove(PersonComponent person)
        {
            this.persons.Remove(person);
        }


        public override void Display(int deapth)
        {
            Console.WriteLine(new string('-',deapth)+this.Name);

            foreach (var person in persons)
            {
                person.Display(deapth + 4);
            }
        }


    }
}
