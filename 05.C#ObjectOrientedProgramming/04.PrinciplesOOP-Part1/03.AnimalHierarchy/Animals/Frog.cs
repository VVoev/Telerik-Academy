namespace _03.AnimalHierarchy.Animals
{
    using AbstractClass;
    using Enumerations;
    using System;
    public class Frog : Animal
    {
        public Frog (string name, int age, SexEnumeration sex) : base (name, age, sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }
        public override string Sound()
        {
            return "QUAQUaquauuauauquuaa";
        }

        public override string ToString()
        {
            return string.Format("Frog sound: " + Sound());
        }
    }
}
