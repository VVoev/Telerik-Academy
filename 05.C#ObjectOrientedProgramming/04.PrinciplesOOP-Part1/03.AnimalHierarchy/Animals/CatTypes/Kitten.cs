namespace _03.AnimalHierarchy.Animals.CatTypes
{
    using Enumerations;

    public class Kitten : Cat
    {
        public Kitten (string name, int age) : base (name, age, SexEnumeration.Female)
        {

        }
        public override string Sound()
        {
            return base.Sound();
        }

        public override string ToString()
        {
            return string.Format("Kitten sound: " + Sound());
        }
    }
}
