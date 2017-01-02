namespace _03.AnimalHierarchy.Animals
{
    using AbstractClass;
    using Enumerations;
    using System;
    public class Dog : Animal
    {
        public Dog (string name, int age, SexEnumeration sex) : base (name, age, sex)
        {
            
        }
        public override string Sound()
        {
            return "Baubaubabaubbauuuuuuu";
        }

        public override string ToString()
        {
            return string.Format("Dog sound: " + Sound());
        }
    }
}
