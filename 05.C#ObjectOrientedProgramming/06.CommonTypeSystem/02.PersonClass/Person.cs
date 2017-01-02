namespace _02.PersonClass
{
    using System;
    using System.Text;

    public class Person
    {
        private string name;
        private int age;

        // Constructors.
        public Person(string name)
        {
            this.name = name;
        }
        public Person(string name, int age) : this (name)
        {
            this.age = age;
        }

        // Properties.
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name == null)
                {
                    throw new ArgumentException("You must enter name.");
                }
                this.name = value;
            }
        }
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (this.age <= 0)
                {
                    throw new ArgumentException("Must enter age.");
                }
                this.age = value;
            }
        }

        // Override ToString method.
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.name);
            if (this.age == 0 || this.age == null)
            {
                sb.AppendLine("Age is not defined.");
            }
            else
            {
                sb.AppendLine("Age " + this.age);
            }
            return sb.ToString();
        }
    }
}
