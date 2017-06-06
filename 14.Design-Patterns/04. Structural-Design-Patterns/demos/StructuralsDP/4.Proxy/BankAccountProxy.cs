namespace _4.Proxy
{
    public class BankAccountProxy : IBankAccount
    {
        private readonly bool isAuthorized;

        private BankAcccount realAccount;

        public BankAccountProxy(string userName, string key)
        {
            if(userName != null && key != null)
            {
                this.isAuthorized = true;
            }

        }

        public bool Deposit(decimal amount)
        {
            if(amount < 25)
            {
                //Logic
                return false;
            }

            if(amount > 1000)
            {
                //Logic
                return false;
            }

            if (!this.isAuthorized)
            {
                return false;
            }

            this.CheckIfAccountIsActive();
            this.realAccount.Deposit(amount);

            return true;
        }

        public bool Withdraw(decimal amount)
        {
            // Do validations
            this.CheckIfAccountIsActive();

            this.realAccount.Withdraw(amount);
            return true;
        }

        public decimal CurrentBalance()
        {
            this.CheckIfAccountIsActive();
            return realAccount.CurrentBalance();
        }

        private void CheckIfAccountIsActive()
        {
            if(this.realAccount == null)
            {
                this.realAccount = new BankAcccount();
            }
        }


    }
}
