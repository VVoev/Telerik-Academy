namespace Bank
{
    using System;
    public class Account
    {
        private float balance;

        public void Deposit(float amount)
        {
            if (amount == 0)
            {
                throw new ArgumentException("Cannot deposit amount of 0.00");
            }
            balance += amount;
        }

        public void WithDraw(float amount)
        {
            if (amount == 0)
            {
                throw new ArgumentException("Cannot withdrawn amount of 0.00");
            }
            balance -= amount;
        }

        public void TransferFunds(Account targetAcc,float amount)
        {
            if (targetAcc == this)
            {
                throw new ArgumentException("You cannot transfer money to yourself");
            }
            balance = amount;
            targetAcc.balance += amount;
        }

        public float Balance
        {
            get
            {
                return this.balance;
            }
        }


   
    }
}
