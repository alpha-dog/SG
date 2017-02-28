using FlooringData;
using FlooringModels;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringTests
{
    [TestFixture] //CANT FIGURE THIS OUT FOR NOW. IM NOT SURE IF ITS NECCESSARY OR DESIRABLE

    class TaxTests
    {
        //set test cases for taxes
        [TestCase("OH", "Ohio", 6.25)]

        //make a function test the results loaded into testRepo or taxesRepo. I don't know whhich
        public void TaxLoadTest(string stateAbrv, string state, decimal taxRate)
        {
            Taxes testTaxes = new Taxes();

            testTaxes.StateAbbreviation = stateAbrv;
            testTaxes.State = state;
            testTaxes.taxRate = taxRate;

           // string filePath = (@"C:\Users\Tom\Documents\SoftwareGuild\Repositories\david-evans-individual-work\FlooringStuff\Taxes.txt");
                
        }


            //[TestCase("33333", "Basic Account", 100, AccountType.Free, 250, false)]
            //[TestCase("33333", "Basic Account", 100, AccountType.Basic, -100, false)]
            //[TestCase("33333", "Basic Account", 100, AccountType.Basic, 250, true)]


            //public void BasicAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
            //{
            //    IDeposit deposit = new NoLimitDepositRule();
            //    Account account = new Account();

            //    account.AccountNumber = accountNumber;
            //    account.Name = name;
            //    account.Balance = balance;
            //    account.Type = accountType;

            //    AccountDepositResponse response = deposit.Deposit(account, amount);

            //    Assert.AreEqual(expectedResult, response.Success);

            }
}
