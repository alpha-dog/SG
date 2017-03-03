﻿using SGBank.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGBank.Models;
using SGBank.Models.Responses;

namespace SGBank.BLL.WithdrawRules
{
    public class BasicAccountWithdrawRule : IWithdraw
    {
        public AccountWithdrawResponse Withdraw(Account account, decimal amount)
        {
            AccountWithdrawResponse response = new AccountWithdrawResponse();

            if (account.Type != AccountType.Basic)
            {
                response.Success = false;
                response.Message = ("Error: a non-basic account hit the Basic Withdraw Rule. Contact IT");
                return response;
            }
            else if (amount >= 0)
            {
                response.Success = false;
                response.Message = ("Withdrawal amounts gotta be negative!");
                return response;
            }
            else if (amount < -500)
            {
                response.Success = false;
                response.Message = "You can't take out that much money. Basic accounts are limited to $500 withdrawals";
                return response;
            }
            else if (account.Balance + amount < -100)
            {
                response.Success = false;
                response.Message = "This amount will overdraft more than your $100 limit";
                return response;
            }
            else
            {
                response.Success = true;
                response.Account = account;
                response.Amount = amount;
                response.OldBalance = account.Balance;
                account.Balance += amount;

                if(account.Balance < 0) //gettin dat overdraft fee
                {
                    account.Balance -= 10;
                }

                return response;
            }

        }
    }
}