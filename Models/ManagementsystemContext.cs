using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FMS.Models;

public partial class ManagementsystemContext : DbContext
{
    public ManagementsystemContext()
    {
    }

    public ManagementsystemContext(DbContextOptions<ManagementsystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<Transactiondetail> Transactiondetails { get; set; }

 //   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
   //     => optionsBuilder.UseNpgsql("Host=ep-late-cherry-a4ke9nci-pooler.us-east-1.aws.neon.tech;Database=Managementsystem;Username=Managementsystem_owner;Password=npg_RBGZjO2mKUx6");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Accountid).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Accountname)
                .HasMaxLength(100)
                .HasColumnName("accountname");
            entity.Property(e => e.Balance)
                .HasPrecision(10, 2)
                .HasColumnName("balance");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.Budgetid).HasName("budget_pkey");

            entity.ToTable("budget");

            entity.Property(e => e.Budgetid).HasColumnName("budgetid");
            entity.Property(e => e.Allocatedamount)
                .HasPrecision(10, 2)
                .HasColumnName("allocatedamount");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.Expenseid).HasName("expenses_pkey");

            entity.ToTable("expenses");

            entity.Property(e => e.Expenseid).HasColumnName("expenseid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Date).HasColumnName("date");
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.Incomeid).HasName("income_pkey");

            entity.ToTable("income");

            entity.Property(e => e.Incomeid).HasColumnName("incomeid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("transactions_pkey");

            entity.ToTable("transactions");

            entity.Property(e => e.Transactionid).HasColumnName("transactionid");
            entity.Property(e => e.Accountid).HasColumnName("accountid");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasColumnName("amount");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.Type)
                .HasMaxLength(10)
                .HasColumnName("type");

            entity.HasOne(d => d.Account).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.Accountid)
                .HasConstraintName("transactions_accountid_fkey");
        });

        modelBuilder.Entity<Transactiondetail>(entity =>
        {
            entity.HasKey(e => e.Transactionid).HasName("transactiondetails_pkey");

            entity.ToTable("transactiondetails");

            entity.Property(e => e.Transactionid)
                .ValueGeneratedNever()
                .HasColumnName("transactionid");
            entity.Property(e => e.Expenseid).HasColumnName("expenseid");
            entity.Property(e => e.Incomeid).HasColumnName("incomeid");

            entity.HasOne(d => d.Expense).WithMany(p => p.Transactiondetails)
                .HasForeignKey(d => d.Expenseid)
                .HasConstraintName("transactiondetails_expenseid_fkey");

            entity.HasOne(d => d.Income).WithMany(p => p.Transactiondetails)
                .HasForeignKey(d => d.Incomeid)
                .HasConstraintName("transactiondetails_incomeid_fkey");

            entity.HasOne(d => d.Transaction).WithOne(p => p.Transactiondetail)
                .HasForeignKey<Transactiondetail>(d => d.Transactionid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("transactiondetails_transactionid_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
