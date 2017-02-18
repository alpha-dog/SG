using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class AccountLoopUpWorkflow
    {
        public void Execute()
        {
            AccountManager manager = AccountManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Lookop an account");
            Console.WriteLine("-------------------------");
            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            AccountLookUpResponse response = manager.LookUpAccount(accountNumber);

            if (response.Success)
            {
                ConsoleIO.DisplayAccountDetails(response.Account);
            }
            else
            {
                Console.WriteLine("an error happened: ");
                Console.WriteLine(response.Message);
            }

            Console.WriteLine("press any key to coninue...");
            Console.ReadKey();
        }
    }
}
