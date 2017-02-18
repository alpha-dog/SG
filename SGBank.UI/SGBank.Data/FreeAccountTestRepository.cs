using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;

namespace SGBank.Data
{
    public class FreeAccountTestRepository : IAccountRepository
    {
        private static Account _account = new Account           //it's static so we can pretend to load and save 
        {                                                       //and any changes made during the program are saved in memory
            Name = "Free Account",
            Balance = 100.00M,
            AccountNumber = "12345",
            Type = AccountType.Free
        };
        public Account LoadAccount(string AccountNumber)
        {
            if(AccountNumber == _account.AccountNumber)
            return _account;

            else
            {
                return null;
            }
        }

        public void SaveAccount(Account account)
        {
            _account = account;
        }
    }
}
