namespace _03.AnimalHierarchy.Animals
{
    using AbstractClass;
    using Enumerations;
    using System;
    public class Cat : Animal
    {
        public Cat (string name, int age, SexEnumeration sex) : base (name, age, sex)
        {

        }
        public override string Sound()
        {
            return "Muaaaaaaaaauuuwwwwww";
        }
    }
}
