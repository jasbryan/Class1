using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassApp1
{
    class BankModel : DbContext
    {

        public virtual DbSet<Account> Accounts { get; set; }

        public BankModel(DbContextOptions<BankModel> options) :base(options)
        {

        }
    }
}
