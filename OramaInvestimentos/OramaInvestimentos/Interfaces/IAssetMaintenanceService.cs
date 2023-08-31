using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IAssetMaintenanceService {    
        public Response.GetFinancialAssets GetFinancialAssets();

        Response.Sucess BuyFinancialAsset(Request.BuyFinancialAsset request, int customerID);

        Response.Sucess SellFinancialAsset(Request.BuyFinancialAsset request, int customerID);
    }
}
