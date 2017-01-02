namespace _02.BankAccounts.BankAccounts
{
    using BankCustomers;

    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal interestRate) : base(customer, interestRate)
        {

        }
        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmount = 0;
            if (this.Customer.GetType().Equals(typeof(Company)))
            {
                if (months <= 12)
                {
                    interestAmount = (this.InterestRate * months) / 2;
                }
                else
                {
                    interestAmount = this.InterestRate * months;
                }
            }
            else if (this.Customer.GetType().Equals(typeof(Individual)))
            {
                int interestMonths = GetMonthsToInterest(months);
                interestAmount = interestMonths * this.InterestRate;
            }
            return interestAmount;
        }
    }
}
