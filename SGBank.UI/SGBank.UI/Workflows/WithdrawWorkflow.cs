using SGBank.BLL;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI.Workflows
{
    public class WithdrawWorkflow
    {
        public void Execute()
        {
            Console.Clear();
            AccountManager accountmanager = AccountManagerFactory.Create();

            Console.Write("Enter an account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter a withdraw amount: ");

            decimal amount = decimal.Parse(Console.ReadLine());

            AccountWithdrawResponse response = accountmanager.Withdraw(accountNumber, amount);

            if (response.Success)
            {
                Console.WriteLine("Withdraw completed!");
                Console.WriteLine($"Account Number {response.Account.AccountNumber}");
                Console.WriteLine($"Amount Deposited: {response.Amount:c}");
                Console.WriteLine($"Old balance: {response.OldBalance:c}");
                Console.WriteLine($"New balance: {response.Account.Balance:c}");


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
