using System;
using System.Collections.Generic;
using System.Text;

namespace ClassApp1
{
    public class InsufficentFundsException : Exception
    {
        public InsufficentFundsException() : base()
        {

        }

        public InsufficentFundsException(string message) : base(message)
        {

        }
    }
}
