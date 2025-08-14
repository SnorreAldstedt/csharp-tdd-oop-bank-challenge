using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccounts
{
    public enum TransactionStatus {Approved, Declined, Pending}
    public class Transaction
    {
        public DateTime Date;
        public string TransactionType;
        public decimal Amount;
        public Transaction? previousTransaction;
        public TransactionStatus status;

        public Transaction(DateTime date, string type, decimal amount, Transaction? previous=null)
        {
            Date = date;
            TransactionType = type;
            Amount = amount;
            previousTransaction = previous;
            status = (TransactionType == "withdraw" && (Amount+CalculateBalance() < 0))? TransactionStatus.Pending : TransactionStatus.Approved;
        }
        public decimal CalculateBalance()
        {
            if (previousTransaction == null) 
            {
                return Amount;
            }
            else
            {
                return previousTransaction.CalculateBalance()+Amount;
            }
        }
    }
}
