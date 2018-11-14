using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ClassApp1
{
    public static class Bank
    {
        #region Properties

        //private static List<Account> BankAccounts = new List<Account>();
        private static BankModel db = new BankModel();
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

            //BankAccounts.Add(tempy);
            db.Accounts.Add(tempy);
            db.SaveChanges();
            return tempy;
            
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Account> GetAllAccounts(string emailAddress)
        {
            //return BankAccounts;
            return db.Accounts.Where(a => a.EmailAddress == emailAddress);
        }

        /// <summary>
        /// Allow user to deposit money to an account number they passed
        /// </summary>
        /// <param name="accountNumber">Account number to use</param>
        /// <param name="depositAmount">Amount of money to deposit to account</param>
        /// <returns></returns>
        public static bool Deposit(Int32 accountNumber, decimal depositAmount)
        {
            //var tempAcct = BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            var tempAcct = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if(tempAcct == null)
            {
                throw new ArgumentNullException("amount");
            }
            var transaction = new Transaction
            {
                Description = "Bank Depoist",
                TypeOfTransaction = TransactionType.Credit,
                Amount = depositAmount,
                AccountNumber = accountNumber
            };

            if(tempAcct.Deposit(depositAmount))
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return true;
            }

            return false;

        }

        public static bool Withdraw(Int32 accountNumber, decimal withdrawAmount)
        {
            //var tempAcct = BankAccounts.SingleOrDefault(a => a.AccountNumber == accountNumber);
            var tempAcct = db.Accounts.SingleOrDefault(a => a.AccountNumber == accountNumber);

            if (tempAcct == null)
            {
                throw new ArgumentNullException("amount");
            }

            var transaction = new Transaction
            {
                Description = "Bank Withdraw",
                TypeOfTransaction = TransactionType.Debit,
                Amount = withdrawAmount,
                AccountNumber = accountNumber
            };


            if (tempAcct.Withdraw(withdrawAmount))
            {
                db.Transactions.Add(transaction);
                db.SaveChanges();
                return true;
            }

            return false;

        }

        public static IEnumerable<Transaction> GetAllTransactions(int accountNumber)
        {
            return db.Transactions.Where(t => t.AccountNumber == accountNumber).OrderByDescending(t => t.TransactionDate);
        }

        public static Account GetAccountDetails(int accountNumber)
        {
            return db.Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);

        }

        public static void EditAccount(Account account)
        {
            var oldAccount = Bank.GetAccountDetails(account.AccountNumber);
            oldAccount.AccountType = account.AccountType;
            oldAccount.EmailAddress = account.EmailAddress;
            db.Update(oldAccount);
            db.SaveChanges();

        }

        public static void DeleteAccount(int accountNumber)
        {
            var accountToDelete = Bank.GetAccountDetails(accountNumber);
            db.Accounts.Remove(accountToDelete);
            db.SaveChanges();
        }

        public static bool AccountExists(int id)
        {
            return db.Accounts.Any(e => e.AccountNumber == id);
        }


        #endregion

    }
}
