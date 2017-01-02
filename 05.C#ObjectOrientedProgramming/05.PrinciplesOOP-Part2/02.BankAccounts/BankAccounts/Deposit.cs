namespace _02.BankAccounts.BankAccounts
{
    using System;
    using BankCustomers;

    public class Deposit : Account
    {
        public Deposit(Customer customer, decimal interestRate) : base(customer, interestRate)
        {

        }
        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmount = 0;
            if (this.Balance >= 1000)
            {
                interestAmount = months * this.InterestRate;
            }
            return interestAmount;
        }
    }
}
