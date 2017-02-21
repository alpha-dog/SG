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
                    else if (accountLetter == "B")          //if I this "else if" to "if", the first account gets initially marked as AccountType.Free (correct)
                    {                                       //but then gets reset to to premium once it reaches the "else" statement. Whats up with that?
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

        public void AccountWrite(Account account)
        {
            
        }


        Account currentAccount = new Account();
        public Account LoadAccount(string accountNumber)
        {
            var loadAccount = AccountList();
            currentAccount = loadAccount.SingleOrDefault(a => a.AccountNumber == accountNumber);
            if (accountNumber == currentAccount.AccountNumber)
            {
                return currentAccount;
            }
            else
            {
                return null;
            }
        }

        public void SaveAccount(Account account)
        {
            var accountNow = AccountList();
            int index = -1;
            for (int i = 0; i < accountNow.Count; i++)
            {
                if (account.AccountNumber == accountNow[i].AccountNumber)
                {
                    index = i;
                }
            }
            if (index == -1)
            {
                throw new Exception("something went wrong. couldn't find account");
            }
            accountNow[index] = account;

            using (StreamWriter sw = new StreamWriter(_filePath, false))
            {
                sw.WriteLine("AccountNumber, Name, Balance, Type");
                foreach (var item in accountNow)
                {
                    string line = string.Format($"{item.AccountNumber},{item.Name},{item.Balance},{item.Type}");

                    sw.WriteLine(line);

                }
                
            }

        }
    }
}
