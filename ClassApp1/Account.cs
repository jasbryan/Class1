﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassApp1
{
    public enum TypesofAccount
    {
        Savings,
        Checking,
        Investment
    }
    /// <summary>
    /// Bank Account object that we can use in this crazy class
    /// </summary>
    public class Account
    {
        //private static int lastAccountNumber = 0;

        #region Properties
        /// <summary>
        /// Account number class stored in an int
        /// </summary>
        public int AccountNumber { get; set; }

        [EmailAddress]      
        public string EmailAddress { get; set; }
        public decimal Balance { get;  set; }
        public TypesofAccount AccountType { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
        #endregion

        #region Constructor

        public Account()
        {
            //AccountNumber = ++lastAccountNumber;
            CreatedDate = DateTime.Now;

        }
        #endregion

        #region methods
        /// <summary>
        /// Add money to the account
        /// </summary>
        /// <param name="amount">amount to add to account</param>
        public bool Deposit(decimal amount)
        {
            Balance += amount;
            return true;
        }

        /// <summary>
        /// Removes money from your account if you have it
        /// </summary>
        /// <param name="amount">amount of money to remove from account</param>
        /// <returns>New balance after withdraw</returns>
        /// <exception cref="InsufficentFundsException" />
        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion

    }
}
        