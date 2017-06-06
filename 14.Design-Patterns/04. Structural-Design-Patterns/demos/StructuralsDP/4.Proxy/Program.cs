using System;

namespace _4.Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            IBankAccount account = new BankAccountProxy("BankAccount", "Interface");

            DisplayBalance(account);
            Deposit(50, account);
            Withdraw(100, account);


        }

        private static void Withdraw(int ammount, IBankAccount account)
        {
            account.Withdraw(ammount);
            Console.WriteLine("Balance has been decreased with {0}", ammount);
            DisplayBalance(account);
        }

        private static void Deposit(int amount, IBankAccount account)
        {
            account.Deposit(amount);
            Console.WriteLine("Balance has been increased with {0}",amount);
            DisplayBalance(account);
        }

        private static void DisplayBalance(IBankAccount account)
        {
            Console.WriteLine($@"Current balance is {account.CurrentBalance()}");
        }
    }



   
}
