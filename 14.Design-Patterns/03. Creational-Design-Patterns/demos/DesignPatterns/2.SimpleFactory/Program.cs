namespace SimpleFactory
{
    public class Program
    {
        static void Main(string[] args)
        {
            var cofeeFactory = new CofeeFactory();
            var capuchinno = cofeeFactory.GetCofee(CofeeType.Capuchinno);
            var doubleCofee = cofeeFactory.GetCofee(CofeeType.Double);
            System.Console.WriteLine(capuchinno);
            System.Console.WriteLine(doubleCofee);
        }
    }
}
