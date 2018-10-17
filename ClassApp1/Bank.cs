using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassApp1
{
    static class Bank
    {
        #region Properties

        private static List<Account> BankAccounts = new List<Account>();
        #endregion

        #region Constructors
        #endregion

        #region Methods
        /// <summary>
        /// Creates new account for user
        /// </summary>
        /// <param name="emailAddress">clients email address</param>
        /// <param name="accountType">Savings or Checking</param>
        /// <param name="initialDeposit">amount to start account with</param>
        /// <returns>Account</returns>
        /// <exception cref="ArgumentNullException" />
        public static Account CreateAccount(string emailAddress,TypesofAccount accountType=TypesofAccount.Checking, decimal initialDeposit = 0)
        {
            if (string.IsNullOrEmpty(emailAddress))
            {
                throw new ArgumentNullException("emailAddress", "EmailAddress is required to create an account!");
            }

            var tempy = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if(initialDeposit > 0)
            {
                tempy.Deposit(initialDeposit);
            }

            BankAccounts.Add(tempy);
            return tempy;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Account> GetAllAccounts()
        {
            return BankAccounts;
        }
        
        /// <summary>
        /// Allow user to deposit money to an account number they passed
        /// </summary>
        /// <param name="accountNumber">Account number to use</param>
        /// <param name="depositAmount">Amount of money to deposit to account</param>
        /// <returns></returns>
        public static decimal Deposit(Int32 accountNumber, decimal depositAmount)
        {
            var tempAcct = BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if(tempAcct == null)
            {
                throw new ArgumentNullException("amount");
            }
            return tempAcct.Deposit(depositAmount);

        }

        public static decimal Withdraw(Int32 accountNumber, decimal withdrawAmount)
        {
            var tempAcct = BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if (tempAcct == null)
            {
                throw new ArgumentNullException("amount");
            }

            return tempAcct.Withdraw(withdrawAmount);

        }
        #endregion

    }
}
