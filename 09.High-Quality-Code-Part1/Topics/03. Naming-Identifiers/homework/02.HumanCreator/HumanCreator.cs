namespace _02.HumanCreator
{
    public class HumanCreator
    {
        public static void Main(string[] args)
        {
            Human firstHuman = Human.MakeHuman(24);
            Human secondHuman = Human.MakeHuman(25);
            System.Console.WriteLine(firstHuman);
            System.Console.WriteLine(secondHuman);
        }
    }
}
