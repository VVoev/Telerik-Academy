namespace TestBank
{
    using System;
    using NUnit.Framework;
    using Bank;

    [TestFixture]
    public class TestAccount
    {
        [Test]
        public void TestDeposit()
        {
            Account acc = new Account();
            acc.Deposit(250);
            float balance = acc.Balance;
            Assert.AreEqual(balance, 250f);
        }

        [Test]
        [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
        public void TestDepositZero()
        {
            Account acc = new Account();
            acc.Deposit(0);
        }

        [Test]
        public void TestDepozitNegative()
        {
            Account acc = new Account();
            acc.Deposit(-220.220f);
            float balance = acc.Balance;
            Assert.AreEqual(balance, -220.220f);
        }

        [Test]
        public void TestWithdraw()
        {
            Account acc = new Account();
            acc.WithDraw(150);
            float balance = acc.Balance;
            Assert.AreEqual(balance, -150);
        }

        [Test]
        [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
        public void TestWidthDrawZero()
        {
            Account acc = new Account();
            acc.WithDraw(0);
        }

        [Test]
        public void TestWithdrawNegative()
        {
            Account acc = new Account();
            acc.WithDraw(-5.25f);
            float balance = acc.Balance;
            Assert.AreEqual(balance, 5);
        }

        [Test]
        public void TestTransferFunds()
        {
            Account source = new Account();
            source.Deposit(500f);
            Account target = new Account();
            target.Deposit(200f);
            source.TransferFunds(target, 100);
            Assert.AreEqual(300, target.Balance);
            Assert.AreEqual(400, source.Balance);
        }


    }
}
