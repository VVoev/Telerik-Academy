namespace _1.Facade
{
    public class Credit
    {
        public bool hasGoodCredit(Customer customer, int ammount)
        {
            System.Console.WriteLine($@"Check credit for {customer.Name}");
            return true;
        }
    }
}
