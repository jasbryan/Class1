using System;
using System.Collections.Generic;
using System.Text;

namespace ClassApp1
{
    static class Bank
    {
        #region Properties
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
        /// <returns>Account object</returns>
        public static Account CreateAccount(string emailAddress,TypesofAccount accountType=TypesofAccount.Checking, decimal initialDeposit = 0)
        {
            var tempy = new Account
            {
                EmailAddress = emailAddress,
                AccountType = accountType
            };

            if(initialDeposit > 0)
            {
                tempy.Deposit(initialDeposit);
            }

            return tempy;
        }


        #endregion

    }
}
