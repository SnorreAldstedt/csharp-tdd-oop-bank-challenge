using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Boolean.CSharp.Main.BankAccounts
{
    public class CurrentAccount : BankAccount
    {
        public CurrentAccount(Guid cID) : base(cID)
        {
        }
    }
}
