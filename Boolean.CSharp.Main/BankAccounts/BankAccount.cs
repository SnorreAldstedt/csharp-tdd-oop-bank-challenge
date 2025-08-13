using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccounts
{
    public class BankAccount
    {
        public Guid accountID {  get; }
        public Guid customerID { get; }
        private List<Transaction> transactions;
        private Transaction? previousTransaction;
        public BankAccount(Guid cID) {
            accountID = Guid.NewGuid();
            customerID = cID;
            transactions = new List<Transaction>();
            previousTransaction = null;
        }
        private void AddTransaction(Transaction transaction)
        {
            previousTransaction = transaction;
            transactions.Add(transaction);
        }
        public void Deposit(decimal amount) 
        {  
            DateTime date = DateTime.Now;
            string type = "deposit";
            Transaction deposit = new Transaction(date, type, amount, previousTransaction); 
            AddTransaction(deposit);
        }
        public void Withdraw(decimal amount)
        {
            DateTime date = DateTime.Now;
            string type = "withdraw";
            Transaction withdraw = new Transaction(date, type, -amount, previousTransaction);
            AddTransaction(withdraw);
        }
        public string GenerateStatement()
        {
            throw new NotImplementedException();
        }
        public decimal GetBalance() 
        {
            if (previousTransaction == null)
            {
                return 0m;
            }
            else
            {
                return previousTransaction.CalculateBalance();
            }
        }
    }
}
