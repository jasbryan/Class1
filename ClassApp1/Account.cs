using System;
using System.Collections.Generic;
using System.Text;

namespace ClassApp1
{
    enum TypesofAccount
    {
        Savings,
        Checking,
        Investment
    }
    /// <summary>
    /// Bank Account object that we can use in this crazy class
    /// </summary>
    class Account
    {
        private static int lastAccountNumber = 0;

        #region Properties
        /// <summary>
        /// Account number class stored in an int
        /// </summary>
        public int AccountNumber { get; }
        public string EmailAddress { get; set; }
        public decimal Balance { get; private set; }
        public TypesofAccount AccountType { get; set; }
        public DateTime CreatedDate { get; }
        #endregion

        #region Constructor

        public Account()
        {
            AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;

        }
        #endregion

        #region methods
        /// <summary>
        /// Add money to the account
        /// </summary>
        /// <param name="amount">amount to add to account</param>
        public decimal Deposit(decimal amount)
        {
            Balance += amount;
            return Balance;
        }
        /// <summary>
        /// REmove money from account if you have it
        /// </summary>
        /// <param name="amount">amount to try and withdraw</param>
        /// <returns></returns>
        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else return false;
        }


        #endregion

    }
}
        