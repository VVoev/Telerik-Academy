using System;

namespace _1.Facade
{
    public class Mortage
    {
        private Bank bank = new Bank();
        private Loan loan = new Loan();
        private Credit credit = new Credit();

        public Mortage()
        {

        }

        public bool isEligible(Customer customer, int money)
        {
            Console.WriteLine($@"Customer {customer.Name} Applied for {money}");
            bool eligible = true;

            //Check Credit for candidate
            if (!bank.hasSufficientSavings(customer, money))
            {
                eligible = false;
            }

            if (!loan.hasNoBadLoans(customer, money))
            {
                eligible = false;
            }

            if (!credit.hasGoodCredit(customer, money)|| money%2 == 0)
            {
                eligible = false;
            }

            return eligible;
        }
    }
}