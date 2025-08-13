using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boolean.CSharp.Main.BankAccounts
{
    public abstract class BankAccount
    {
        public Guid accountID {  get; }
        public Guid customerID { get; }
        //private List<Transaction> transactions;
        private Transaction? previousTransaction;
        public BankAccount(Guid cID) {
            accountID = Guid.NewGuid();
            customerID = cID;
            //transactions = new List<Transaction>();
            previousTransaction = null;
        }
        private void AddTransaction(Transaction transaction)
        {
            previousTransaction = transaction;
            //transactions.Add(transaction);
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
        private void appendCell(StringBuilder sb, string str, int width, string prefix = " ", string suffix= "||")
        {
            sb.Append(prefix);
            sb.Append(str);
            sb.Append(' ', width - (prefix + str).Length);
            sb.Append(suffix);
        }
        private void appendStatementLine(StringBuilder sb, string date, string credit, string debit, string balance, int width = 12) 
        {
            appendCell(sb, date, width);
            appendCell(sb, credit, width);
            appendCell(sb, debit, width);
            appendCell(sb, balance, width);
            sb.Append("\r\n");
        }

        private (string, string, string, string) getAllStrings(Transaction transaction)
        {
            string dateStr = transaction.Date.ToString("dd-MM-yyyy");
            string creditStr = (transaction.TransactionType == "deposit") ? transaction.Amount.ToString() : " ";
            string debitStr = (transaction.TransactionType == "withdraw") ? transaction.Amount.ToString() : " ";
            string balanceStr = Math.Round(transaction.CalculateBalance(),2).ToString();
            return (dateStr, creditStr, debitStr, balanceStr);
        } 
        public string GenerateStatement()
        {
            int cellWidth = 12;
            StringBuilder statementBuilder = new StringBuilder();
            string dateStr = "date";
            string creditStr = "credit";
            string debitStr = "debit";
            string balanceStr = "balance";
            appendStatementLine(statementBuilder, dateStr, creditStr, debitStr, balanceStr);
            while (previousTransaction != null)
            {
                var tStrs = getAllStrings(previousTransaction);
                appendStatementLine(statementBuilder, tStrs.Item1, tStrs.Item2, tStrs.Item3, tStrs.Item4);
                previousTransaction = previousTransaction.previousTransaction;
            }
            return statementBuilder.ToString();
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
