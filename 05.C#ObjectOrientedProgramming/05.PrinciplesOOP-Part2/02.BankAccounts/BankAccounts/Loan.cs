namespace _02.BankAccounts.BankAccounts
{
    using BankCustomers;

    public class Loan : Account
    {
        public Loan(Customer customer, decimal interestRate) : base(customer, interestRate)
        {

        }
        public override decimal CalculateInterestAmount(int months)
        {
            decimal interestAmount = 0;
            int interestMonths = GetMonthsToInterest(months);
            interestAmount = interestMonths * this.InterestRate;
            return interestAmount;
        }

        public override int GetMonthsToInterest(int numberOfMonths)
        {
            if (this.Customer.GetType().Equals(typeof(Individual)))
            {
                numberOfMonths -= 3;
            }
            else if (this.Customer.GetType().Equals(typeof(Company)))
            {
                numberOfMonths -= 2;
            }
            return numberOfMonths;
        }
    }
}
