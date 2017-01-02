namespace _03.AnimalHierarchy.AbstractClass
{
    using Animals.Enumerations;
    using Interfaces;
    using System;
    using System.Collections;
    public abstract class Animal : IEnumerable, ISound 
    {
        // Fields.
        protected string name;
        protected int age;
        protected SexEnumeration sex;

        public Animal(string name, int age, SexEnumeration sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        // Properties.
        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Enter a name for this animal.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get { return this.age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must be a positive integer.");
                }
                this.age = value;
            }
        }
        public SexEnumeration Sex
        {
            get { return this.sex; }
            set
            {
                this.sex = value;
            }
        }

        // Methods.
        public abstract string Sound();

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
