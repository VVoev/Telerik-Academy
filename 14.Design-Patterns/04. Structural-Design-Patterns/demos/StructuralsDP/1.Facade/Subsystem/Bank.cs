using System;

namespace _1.Facade
{
    public class Bank
    {
        public bool hasSufficientSavings(Customer customer, int ammount)
        {
            Console.WriteLine($@"Check back for {customer.Name}");
            return true;
        }
    }
}
