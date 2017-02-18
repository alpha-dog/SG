using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class DepositWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountmanager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a deposit amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountDepositResponse response = accountmanager.Deposit(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Deposit completed!");
                Console.WriteLine($"Account Number {response.Account.AccountNumber}");
                Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                Console.WriteLine($"Old blance: {response.OldBalance:c}");
                Console.WriteLine($"New blance: {response.Account.Balance:c}");


            }
            else
            {
                Console.WriteLine("an error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("press any key to continue...");
            Console.ReadKey();

        }
    }
}
