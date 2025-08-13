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
        public BankAccount(Guid cID) {
            accountID = new Guid();
            customerID = cID;
            transactions = new List<Transaction>();
        }
        private void AddTransaction(decimal transaction)
        {
            throw new NotImplementedException();
        }
        public void Deposit(decimal amount) 
        {  
            throw new NotImplementedException(); 
        }
        public void Withdraw(decimal amount)
        {
            throw new NotImplementedException();
        }
        public void GenerateStatement(decimal amount)
        {
            throw new NotImplementedException();
        }
        public decimal GetBalance() 
        {  
            throw new NotImplementedException();
        }
    }
}
