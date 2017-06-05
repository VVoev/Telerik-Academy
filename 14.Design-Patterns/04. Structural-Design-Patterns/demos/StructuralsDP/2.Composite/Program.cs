namespace _2.Composite
{
    class Program
    {
        static void Main()
        {
            var king = new Commander("Leonidas");

            var grandGeneral = new Commander("Xena The Princess Warrior");
            king.Add(grandGeneral);

            var generalProtos = new Commander("General Protos");
            grandGeneral.Add(generalProtos);

            var officerTonga = new Commander("Officer Tonga");
            generalProtos.Add(officerTonga);
            officerTonga.Add(new Person("Kin"));
            officerTonga.Add(new Person("Briko"));
            officerTonga.Add(new Person("Zaler"));

            king.Display(1);
            officerTonga.Display(1);
        }
    }
}
