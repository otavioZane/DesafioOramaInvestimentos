using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Db.Repository;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IAssetMaintenanceRepository {

        public List<FinancialAssetParam> GetFinancialAsset();

        public FinancialAssetParam GetFinancialAssetById(int assetID);
        public bool AddFinancialTransaction(FinancialTransactionParam request, decimal balance);
        List<FinancialTransactionParam> GetFinancialTransactionsByAccountId(int accountID, int assetID);
    }
}
