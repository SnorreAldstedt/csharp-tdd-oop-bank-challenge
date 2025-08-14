using Boolean.CSharp.Main;
using Boolean.CSharp.Main.BankAccounts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Test
{
    [TestFixture]
    public class ExtensionTests
    {
        private Extension _extension;
        public ExtensionTests()
        {
            _extension = new Extension();
        }
        [Test]
        public void PendingStatusTest()
        {
            Guid cID = Guid.NewGuid();
            CurrentAccount account = new CurrentAccount(cID);

            account.Withdraw(1000m);
            decimal balance = account.GetBalance();

            List<Transaction> pending =account.GetPendingTransactions();

            Assert.AreEqual(-1000m, balance);
            Assert.That(pending.Count == 1);
        }
    }
}
