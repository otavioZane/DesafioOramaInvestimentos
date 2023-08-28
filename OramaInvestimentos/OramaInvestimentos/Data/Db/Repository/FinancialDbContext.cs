using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Entities;

namespace OramaInvestimentos.Data.Db.Repository {

    public class FinancialDbContext : DbContext {

        public FinancialDbContext() {

        }

        public FinancialDbContext(DbContextOptions<FinancialDbContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<FinancialAsset> FinancialAssets { get; set; }
        public DbSet<FinancialTransaction> FinancialTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Customer>()
                .HasKey(x => x.customerID);

            modelBuilder.Entity<Customer>()
                .HasIndex(x => x.email).IsUnique();

            modelBuilder.Entity<FinancialAsset>()
                .HasKey(x => x.assetID);

            modelBuilder.Entity<BankAccount>()
                .HasKey(x => x.accountID);

            modelBuilder.Entity<FinancialTransaction>()
                .HasKey(x => x.transactionID);

            modelBuilder.Entity<BankAccount>()
                .Property(x => x.balance)
                .HasDefaultValue(10000);

            modelBuilder.Entity<BankAccount>()
                .HasOne<Customer>(c => c.customer)
                .WithOne(ba => ba.bankAccount).HasForeignKey<BankAccount>(ba => ba.customerID);

            modelBuilder.Entity<FinancialAsset>()
               .HasOne(ft => ft.transaction)
               .WithOne(fa => fa.financialAsset).HasForeignKey<FinancialAsset>(fa => fa.assetID);

            modelBuilder.Entity<FinancialTransaction>()
                .HasOne(ba => ba.bankAccount)
                .WithMany(ft => ft.transactions).HasForeignKey(ft => ft.accountID);

        }

    }
}

