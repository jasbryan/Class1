using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ClassApp1
{

    public enum TransactionType
    {
        Credit,
        Debit
    }
    public class Transaction
    {
        #region Properties

        public int TransactionId { get; set; }
                
        public DateTime TransactionDate { get; set; }

        public string Description { get; set; }

        public TransactionType TypeOfTransaction { get; set; }

        public decimal Amount { get; set; }

        [ForeignKey("Account")]
        public int AccountNumber { get; set; }

        public virtual Account Account { get; set; }

        #endregion

        public Transaction()
        {
            TransactionDate = DateTime.Now;
        }




    }
}
