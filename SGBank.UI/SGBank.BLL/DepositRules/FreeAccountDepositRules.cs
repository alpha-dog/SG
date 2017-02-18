using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.DepositRules
{
    public class FreeAccountDepositRule : IDeposit
    {
        public AccountDepositResponse Deposit(Account account, decimal amount)
        {
            AccountDepositResponse response = new AccountDepositResponse();

            if (account.Type != AccountType.Free)
            {
                response.Success = false;
                response.Message = ("Error: a non free account hit the Free Deposit Rule.");
                return response;
            }
            if(amount > 100)
            {
                response.Success = false;
                response.Message = "free accounts can't deposit more than $100 at a time";
                return response;
            }
            if(amount <= 0)
            {
                response.Success = false;
                response.Message = "depost amounts must be freater tha ero.";
                return response;
            }
            response.Success = true;
            response.Account = account;
            response.Amount = amount;
            response.OldBalance = account.Balance;
            account.Balance += amount;

            return response;
        }
    }
}
