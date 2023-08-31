using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;

namespace OramaInvestimentos.Data.Db.Repository {
    public class AssetMaintenanceRepository : IAssetMaintenanceRepository {

        private readonly ILogger _logger;
        private readonly FinancialDbContext _dbContext;

        public AssetMaintenanceRepository(ILogger logger, JwtConfig jwtConfig, FinancialDbContext dbContext) {

            _logger = logger;
            _dbContext = dbContext;
        }

        public List<FinancialAssetParam> GetFinancialAsset() {
            var response = _dbContext.FinancialAssets
                .ToList();
            return response;
        }

        public FinancialAssetParam GetFinancialAssetById(int assetID) {
            var response = _dbContext.FinancialAssets
                .Where(x => x.assetID.Equals(assetID))
                .FirstOrDefault();
            return response;
        }

        public List<FinancialTransactionParam> GetFinancialTransactionsByAccountId(int accountID, int assetID) {
            var response = _dbContext.FinancialTransactions
                .Where(x => x.assetID.Equals(assetID) && x.accountID.Equals(accountID))
                .ToList();
            return response;
        }

        public bool AddFinancialTransaction(FinancialTransactionParam request, decimal balance) {
            var account = _dbContext.BankAccounts.Where(x => x.accountID == request.accountID).FirstOrDefault();
            if (account == null) {
                return false;
            }
            request.transactionID = null;
            account.transactions.Add(request);
            account.balance = balance;
            _dbContext.BankAccounts.Update(account);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
