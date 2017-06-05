namespace Ice_Cream
{
    public class Startup
    {
        static void Main(string[] args)
        {
            var factory = new IceCreamFactory();
            var caramelCream = factory.GetIceCream(Types.Caramel);
            var vanilaCream = factory.GetIceCream(Types.Vanilla);
            var chocolateCream = factory.GetIceCream(Types.Chocolate);



        }
    }
}
