namespace _4.Proxy
{
    interface IBankAccount
    {
        bool Deposit(decimal amount);

        bool Withdraw(decimal amount);

        decimal CurrentBalance();
    }
}
