namespace _02.BankAccounts
{
    using BankAccounts;
    using BankCustomers;
    using System;
    using System.Collections.Generic;
    class BankAccountsTest
    {
        static void Main()
        {
            // Create customer Deposit account.
            var companyCustomer = new Company("IBM");
            var companyDeposit = new Deposit(companyCustomer,1.5m );
            companyDeposit.DepositMoney(10000m);
            companyDeposit.WithDrawMoney(1500m);
            decimal amount = companyDeposit.CalculateInterestAmount(6);
            companyDeposit.Balance -= amount;
            Console.WriteLine(companyDeposit);

            // Create individual Loan account.
            var individualCustomer = new Individual("Ivan Ivanov");
            var individualLoan = new Loan(individualCustomer, 5m);
            individualLoan.Balance = 15000;
            decimal yearAmount = individualLoan.CalculateInterestAmount(12);
            individualLoan.Balance -= yearAmount;
            Console.WriteLine(individualLoan);

            // Create individual Mortgage account.
            var mortgageCustomer = new Individual("Angel Angelov");
            var individualMortgage = new Mortgage(mortgageCustomer, 4.5m);
            individualMortgage.Balance = 45000m;
            decimal mortgageAmount = individualMortgage.CalculateInterestAmount(12);
            individualMortgage.Balance -= mortgageAmount;
            Console.WriteLine(individualMortgage);

            // Create list of Accounts.
            Console.WriteLine("-------------------------------");
            var listOfAccounts = new List<Account>() {companyDeposit,individualLoan, individualMortgage };
            listOfAccounts.ForEach(x => Console.WriteLine(x.Customer.CustomerName + " " + x.Balance + " leva."));
        }
    }
}
