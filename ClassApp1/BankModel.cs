using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassApp1
{
    public class BankModel : DbContext
    {

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<Transaction> Transactions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyBankDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
           {
               entity.HasKey(e => e.AccountNumber)
               .HasName("PK_Account");

               entity.Property(e => e.AccountNumber)
               .ValueGeneratedOnAdd();

               entity.Property(e => e.EmailAddress)
               .HasMaxLength(50);

               entity.HasMany(e => e.Transactions);

               entity.ToTable("Accounts");


           });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                .HasName("PK_Transation");

                entity.Property(e => e.TransactionId)
                .ValueGeneratedOnAdd();

                entity.Property(e => e.TransactionDate)
                .ValueGeneratedOnAdd();

                entity.HasOne(e => e.Account);

                entity.ToTable("Transactions");
                               
            });

        }

    }
}
