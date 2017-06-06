using System;

namespace _4.Proxy
{
    class BankAcccount : IBankAccount
    {

        public BankAcccount()
        {
            this.Balance = 2500;
        }

        private decimal Balance { get; set; }

        public decimal CurrentBalance()
        {
            return this.Balance;
        }

        public bool Deposit(decimal amount)
        {
            this.Balance += amount;
            return true;
        }

        public bool Withdraw(decimal amount)
        {
            this.Balance -= amount;
            return true;
        }
    }
}
