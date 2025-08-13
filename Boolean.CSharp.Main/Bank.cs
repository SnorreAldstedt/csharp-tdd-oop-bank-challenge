using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boolean.CSharp.Main.BankAccounts;
using NUnit.Framework.Constraints;

namespace Boolean.CSharp.Main
{
    public class Bank
    {
        public string Name { get; set; }
        private Dictionary<Guid, Dictionary<Guid, BankAccount>> Accounts { get; }
        public Bank(string name) 
        {
            Name = name;
            Accounts = new Dictionary<Guid, Dictionary<Guid, BankAccount>>();
        }

        public void CreateCurrentAccount(Guid customerID)
        {
            CurrentAccount current = new CurrentAccount(customerID);

            if (!Accounts.ContainsKey(customerID))
            {
                Accounts[customerID] = new Dictionary<Guid, BankAccount>();
            }
            Accounts[customerID][current.accountID] = current;
        }

        public void CreateSavingsAccount(Guid customerID)
        {
            SavingsAccount current = new SavingsAccount(customerID);
            if (!Accounts.ContainsKey(customerID))
            {
                Accounts[customerID] = new Dictionary<Guid, BankAccount>();
            }
            Accounts[customerID][current.accountID] = current;
        }

        public BankAccount GetAccount(Guid customerID, Guid accountID)
        {
            return Accounts[customerID][accountID];
        }

        public List<BankAccount> GetCustomerAccounts(Guid customerID)
        {
            if (Accounts.ContainsKey(customerID))
            {
                return Accounts[customerID].Values.ToList();
            }
            else
            {
                return new List<BankAccount>();
            }
        }
    }
}
