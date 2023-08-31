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

        public DbSet<CustomerParam> Customers { get; set; }
        public DbSet<BankAccountParam> BankAccounts { get; set; }
        public DbSet<FinancialAssetParam> FinancialAssets { get; set; }
        public DbSet<FinancialTransactionParam> FinancialTransactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<CustomerParam>()
                .HasKey(x => x.customerID);

            modelBuilder.Entity<CustomerParam>()
                .HasIndex(x => x.email).IsUnique();

            modelBuilder.Entity<FinancialAssetParam>()
                .HasKey(x => x.assetID);

            modelBuilder.Entity<BankAccountParam>()
                .HasKey(x => x.accountID);

            modelBuilder.Entity<FinancialTransactionParam>()
                .HasKey(x => x.transactionID);

            modelBuilder.Entity<BankAccountParam>()
                .Property(x => x.balance)
                .HasDefaultValue(90000);

            modelBuilder.Entity<BankAccountParam>()
                .HasOne<CustomerParam>(c => c.customer)
                .WithOne(ba => ba.bankAccount).HasForeignKey<BankAccountParam>(ba => ba.customerID);

            modelBuilder.Entity<FinancialTransactionParam>()
               .HasOne(ft => ft.financialAsset)
               .WithMany(fa => fa.transactions).HasForeignKey(x => x.assetID);

            modelBuilder.Entity<FinancialTransactionParam>()
                .HasOne(ba => ba.bankAccount)
                .WithMany(ft => ft.transactions).HasForeignKey(ft => ft.accountID);

            //O codigo a seguir preenche o banco com algumas ações modelo.
            //Seed inicial para popular tabela
            modelBuilder.Entity<FinancialAssetParam>().HasData(
            new[] {
            new FinancialAssetParam { assetID = 1, name = "ABC Stock", price = 100 },
            new FinancialAssetParam { assetID = 2, name = "DEF Stock", price = 100 },
            new FinancialAssetParam { assetID = 3, name = "GHI Stock", price = 100 },
            new FinancialAssetParam { assetID = 4, name = "JKL Stock", price = 100 },
            new FinancialAssetParam { assetID = 5, name = "MNO Stock", price = 100 },
            new FinancialAssetParam { assetID = 6, name = "PQR Stock", price = 100 },
            new FinancialAssetParam { assetID = 7, name = "STU Stock", price = 100 },
            new FinancialAssetParam { assetID = 8, name = "VWX Stock", price = 100 },
            new FinancialAssetParam { assetID = 9, name = "YZA Stock", price = 100 },
            new FinancialAssetParam { assetID = 10, name = "BCD Stock", price = 100 }}
        //Adicione mais exemplos aqui, se for necessário.
        ) ;
        }
    }
}


