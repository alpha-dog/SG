using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class PremiumAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Premium)
            {
                response.Success = false;
                response.Message = "error: a non-primo account hit the premium withdraw rulel. Call IT";
                return response;
            }
            else if (amount >= 0)
            {
                response.Success = false;
                response.Message = "withdraw amount gotta be negative";
                return response;
            }
            else
            {
                response.Success = true;
                response.Account = account;
                response.Amount = amount;
                response.OldBalance = account.Balance;
                account.Balance += amount;

                if(account.Balance < -500)
                {
                    account.Balance -= 10;
                }

                return response;
            }

        }
    }
}
