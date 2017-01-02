namespace _03.AnimalHierarchy.Animals.CatTypes
{
    using Enumerations;

    public class Tomcat : Cat
    {

        public Tomcat (string name, int age) : base (name, age, SexEnumeration.Male)
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
