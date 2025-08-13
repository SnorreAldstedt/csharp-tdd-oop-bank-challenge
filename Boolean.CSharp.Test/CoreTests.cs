using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccounts;
using NUnit.Framework;
using System.Security.Cryptography;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class CoreTests
    {
        private Core _core;

        public CoreTests()
        {
            _core = new Core();

        }
        [Test]
        public void CreateCurrentAccountTest()
        {
            Guid cID = Guid.NewGuid();
            BankAccount account = new CurrentAccount(cID);

            Assert.That(account.GetType() == typeof(CurrentAccount));
        }
        [Test]
        public void CreateSavingsAccountTest()
        {
            Guid cID = Guid.NewGuid();
            BankAccount account = new SavingsAccount(cID);

            Assert.That(account.GetType() == typeof(SavingsAccount));
        }
        [Test]
        public void DepositCurrentAccountTest()
        {
            Guid cID = Guid.NewGuid();
            CurrentAccount account = new CurrentAccount(cID);

            account.Deposit(1000m);
            decimal balance = account.GetBalance();

            Assert.AreEqual(1000m, balance);
        }
        [Test]
        public void DepositSavingsAccountTest()
        {
            Guid cID = Guid.NewGuid();
            SavingsAccount account = new SavingsAccount(cID);
            account.Deposit(500m);

            decimal balance = account.GetBalance();

            Assert.AreEqual(500m, balance);

        }
        [Test]
        public void WithdrawCurrentAccountTest()
        {
            Guid cID = Guid.NewGuid();
            CurrentAccount account = new CurrentAccount(cID);

            account.Withdraw(1000m);
            decimal balance = account.GetBalance();

            Assert.AreEqual(-1000m, balance);
        }

        [Test]
        public void WithdrawSavingsAccountTest()
        {
            Guid cID = Guid.NewGuid();
            SavingsAccount account = new SavingsAccount(cID);
            account.Withdraw(500m);

            decimal balance = account.GetBalance();

            Assert.AreEqual(-500m, balance);

        }

        [Test]
        public void CreateBankTest()
        {
            string bankName = "testBank";
            Bank myBank = new Bank(bankName);
            Assert.AreEqual(myBank.Name, bankName);
        }
        [Test]
        public void CreateBankCustomerNoAccountTest()
        {
            string bankName = "testBank";
            Bank myBank = new Bank(bankName);
            Guid cID = Guid.NewGuid();

            Assert.That(myBank.GetCustomerAccounts(cID).Count == 0);
        }
        [Test]
        public void CreateAccountTest()
        {
            Bank myBank = new Bank("testBank");
            Guid cID = Guid.NewGuid();
            myBank.CreateAccount(cID);
            
            Assert.That(myBank.GetCustomerAccounts(cID).Count == 1);
        }

        [Test]
        public void CheckEmptyBalanceTest()
        {
            Bank myBank = new Bank("testBank");
            Guid cID = Guid.NewGuid();
            myBank.CreateAccount(cID);
            Guid accountGuid = myBank.GetCustomerAccounts(cID)[0].accountID;
            BankAccount account = myBank.GetAccount(cID, accountGuid);
            decimal balance = account.GetBalance();
            Assert.That(balance == 0m);
        }

        [Test]
        public void GenerateStatementTest()
        {
            Guid cID = Guid.NewGuid();
            CurrentAccount account = new CurrentAccount(cID);

            account.Deposit(1000m);
            account.Withdraw(250m);
            decimal balance = account.GetBalance();

            string statement = account.GenerateStatement();
            Assert.AreEqual(750m, balance);
            Assert.That(
                statement.Contains("1000") &&
                statement.Contains("250") &&
                statement.Contains("750") &&
                statement.Contains("date") &&
                statement.Contains("credit") &&
                statement.Contains("debit") &&
                statement.Contains("balance"));
        }
    }
}