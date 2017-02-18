using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBankTest
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [TestCase("77777", "Premium Account", 100, AccountType.Free, 250, false)]
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, -100, false)]
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, 250, true)]


        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [TestCase("77777", "Premium Account", 600, AccountType.Premium, -1000, -400, true)] //success without OD fee
        [TestCase("77777", "Premium Account", 100, AccountType.Free, -100, 100, false)]     //not a premium ccount
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, 100, 100, false)]     //positive withdraw attempt  
        [TestCase("77777", "Premium Account", 100, AccountType.Premium, -650, -560, true)]     //success with OD fee (-60 = balance(100) - (withdrawal)150 - (OD Fee)10


        public void PremiumAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, decimal newBalance, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account();

            account.AccountNumber = accountNumber;
            account.Name = name;
            account.Balance = balance;
            account.Type = accountType;

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

            if (response.Success)
            {
                Assert.AreEqual(newBalance, response.Account.Balance);
            }
        }
    }
}
