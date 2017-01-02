namespace _02.BankAccounts.BankAccounts
{
    using BankCustomers;
    using BankInterfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Account : IAccountable
    {
        // Fields.
        private Customer customer;
        private decimal balance;
        private decimal interestRate;
        private decimal interestAmount;

        // Properties.
        public Customer Customer { get; }
        public decimal Balance { get; set; }
        protected decimal InterestRate { get; set; }
        protected decimal InterestAmount { get; set; }

        // Constructors.
        public Account(Customer customer, decimal interestRate)
        {
            this.Customer = customer;
            this.InterestRate = interestRate;
        }
        // Methods.
        public abstract decimal CalculateInterestAmount(int months);
        public virtual void DepositMoney(decimal money)
        {

            this.Balance += money;
        }
        public virtual void WithDrawMoney(decimal money)
        {
            if (this.Balance < money)
            {
                this.Balance = 0;
            }
            this.Balance -= money;
        }
        public virtual int GetMonthsToInterest(int numberOfMonths)
        {
            return numberOfMonths;
        }
        public override string ToString()
        {
            return string.Format(this.Customer.CustomerName + " has balance of " + this.Balance + " leva.");
        }
    }
}
