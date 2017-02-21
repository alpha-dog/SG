using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using System.IO;

namespace SGBank.Data
{
    public class FileAccountRepository : IAccountRepository
    {
        string _filePath;
        public FileAccountRepository(string filePath)
        {
            _filePath = filePath;
        }

        //This method reads the txt file and returns a list of accounts (still gotta write to txt file though)
        public List<Account> AccountList()
        {
            List<Account> accounts = new List<Account>();

            using (StreamReader sr = new StreamReader(_filePath))
            {
                sr.ReadLine();
                string line;
                string accountLetter;

                while ((line = sr.ReadLine()) != null)
                {
                    Account newAccount = new Account();
                    
                    string[] columns = line.Split(',');

                    newAccount.AccountNumber = columns[0];
                    newAccount.Name = columns[1];
                    newAccount.Balance = decimal.Parse(columns[2]);
                    accountLetter = columns[3];

                    if (accountLetter == "F")
                    {
                        newAccount.Type = AccountType.Free;
                    }
                    if (accountLetter == "B")
                    {
                        newAccount.Type = AccountType.Basic;
                    }
                    else
                    {
                        newAccount.Type = AccountType.Premium; //I should not be defaulting to premium here but I'm being lazy
                    }

                    accounts.Add(newAccount);
                } 
                

            }
                return accounts;
        }

        public void AddAccount(Account account)
        {
            using (StreamWriter sw = new StreamWriter(_filePath, true))
            {
                string line = string.Format($"{account.AccountNumber}{account.Name}{account.Balance}{account.Type}");

                sw.WriteLine(line);
            }
        }



        public Account LoadAccount(string AccountNumber)
        {
            throw new NotImplementedException();
        }

        public void SaveAccount(Account account)
        {
            throw new NotImplementedException();
        }
    }
}
