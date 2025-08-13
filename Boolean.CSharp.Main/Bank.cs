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

        public void CreateAccount(Guid customerID)
        {
            throw new NotImplementedException();
        }

        public BankAccount GetAccount(Guid customerID, Guid accountID)
        {
            throw new NotImplementedException();
        }

        public List<BankAccount> GetCustomerAccounts(Guid customerID)
        {
            throw new NotImplementedException();
        }


    }
}
