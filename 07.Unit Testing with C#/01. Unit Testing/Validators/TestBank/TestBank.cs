using System;
using NUnit.Framework;
using BankProject;

[TestFixture,Explicit]
public class TestBanks
{
    [SetUp]
    public void InitBeforeEachTest()
    {
        // TODO: to be implemented, remove ignore attribute
    }

    [TearDown]
    public void DisposeAfterEachTest()
    {
        // TODO: to be implemented, remove ignore attribute
    }


    [TestFixtureSetUp]
    public void Init()
    {
        // TODO: to be implemented
    }

    [TestFixtureTearDown]

    public void Dispose()
    {
        // TODO: to be implemented
    }

    [Test]
    public void TestBankAddAccount()
    {
        Bank bank = new Bank();
        Account acc = new Account();
        bank.AddAccount(acc);
        Assert.AreEqual(bank.AccountsCount, 1);
        Assert.AreSame(bank[0], acc);
    }

    [Test]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
    public void TestBankAddNullAccount()
    {
        Bank bank = new Bank();
        bank.AddAccount(null);
    }

    [Test]
    public void TestBankAddRemoveAccount()
    {
        Bank bank = new Bank();
        Account acc = new Account();
        bank.AddAccount(acc);
        Assert.AreEqual(bank.AccountsCount, 1);
        bank.RemoveAcc(acc);
        Assert.AreEqual(bank.AccountsCount, 0);
    }

    [Test]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
    public void TestBankRemoveInvalidAccount()
    {
        Bank bank = new Bank();
        Account acc = new Account();
        bank.AddAccount(acc);
        Account anotherAcc = new Account();
        bank.RemoveAcc(anotherAcc);
    }

    [Test]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
    public void TestBankRemoveNullAccount()
    {
        Bank bank = new Bank();
        bank.RemoveAcc(null);
    }

    [Test]
    public void TestBankAccountIndexer()
    {
        Bank bank = new Bank();
        Account acc = new Account();
        bank.AddAccount(acc);
        Account sameAcc = bank[0];
        Assert.AreSame(acc, sameAcc);

        Account secondAcc = new Account();
        bank.AddAccount(secondAcc);
        Account sameSecondAcc = bank[1];
        Assert.AreSame(secondAcc, sameSecondAcc);

        Assert.AreNotSame(sameAcc, sameSecondAcc);
    }

    [Test]
    [Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentException))]
    public void TestBankAccountIndexerInvalidRange()
    {
        Bank bank = new Bank();
        Account acc = new Account();
        bank.AddAccount(acc);
        Account accFromBank = bank[1];
    }

    [Test]
    public void TestBankIgnoreTest()
    {
        // TODO: to be implemented
    }
}