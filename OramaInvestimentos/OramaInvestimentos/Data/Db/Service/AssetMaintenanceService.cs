using Microsoft.AspNetCore.Mvc;
using OramaInvestimentos.Data.Db.Repository;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using System.Net;

namespace OramaInvestimentos.Data.Db.Service {
    public class AssetMaintenanceService : IAssetMaintenanceService {

        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;
        private readonly IAssetMaintenanceRepository _assetMaintenanceRepository;

        public AssetMaintenanceService(
            ILogger logger,
            IUserRepository userRepository,
            IBankAccountRepository bankAccountRepository,
            IAssetMaintenanceRepository assetMaintenanceRepository
        ) {
            _logger = logger;
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
            _assetMaintenanceRepository = assetMaintenanceRepository;
        }

        public Response.GetFinancialAssets GetFinancialAssets() {

            var assets = _assetMaintenanceRepository.GetFinancialAsset();
            var response = new Response.GetFinancialAssets() { assets = assets };

            return response;
        }

        public Response.Sucess BuyFinancialAsset(Request.BuyFinancialAsset request, int customerID) {

            var user = _userRepository.FindUserById(customerID);
            var asset = _assetMaintenanceRepository.GetFinancialAssetById(request.assetID);
            var total = request.quantity * asset.price;
            if (total > user.bankAccount.balance) {
                throw new CustomError("Saldo insuficiente.", HttpStatusCode.BadRequest);
            }
            user.bankAccount.balance -= total;
            var transaction = new FinancialTransactionParam() {
                accountID = user.bankAccount.accountID,
                assetID = asset.assetID,
                bankAccount = user.bankAccount,
                financialAsset = asset,
                date = DateTime.Now,
                quantity = request.quantity,
                type = "buy",
                totalValue = total
            };
            _assetMaintenanceRepository.AddFinancialTransaction(transaction, user.bankAccount.balance);
            return new Response.Sucess() {
                message = "Compra realizada com sucesso."
            };
        }

        private int CalculateQuantity(List<FinancialTransactionParam> transactions) {
            var quantity = 0;
            foreach (var transaction in transactions) {
                quantity += transaction.quantity;
            }
            return quantity;
        }

        public Response.Sucess SellFinancialAsset(Request.BuyFinancialAsset request, int customerID) {

            var user = _userRepository.FindUserById(customerID);
            var asset = _assetMaintenanceRepository.GetFinancialAssetById(request.assetID);
            var transactions = user.bankAccount.transactions.Where(x => x.assetID == request.assetID);
            var transactionsBuy = CalculateQuantity(transactions.Where(x => x.type.Equals("buy")).ToList());
            var transactionsSell = CalculateQuantity(transactions.Where(x => x.type.Equals("sell")).ToList());        
            var totalSellTransactions = transactionsSell + request.quantity;
            var total = request.quantity * asset.price;
            if (totalSellTransactions > transactionsBuy) {
                throw new CustomError("Ações insuficiente.", HttpStatusCode.BadRequest);
            }
            user.bankAccount.balance += total;
            var transaction = new FinancialTransactionParam() {
                accountID = user.bankAccount.accountID,
                assetID = asset.assetID,
                bankAccount = user.bankAccount,
                financialAsset = asset,
                date = DateTime.Now,
                quantity = request.quantity,
                type = "sell",
                totalValue = total
            };
            _assetMaintenanceRepository.AddFinancialTransaction(transaction, user.bankAccount.balance);
            return new Response.Sucess() {
                message = "Venda realizada com sucesso."
            };
        }


    }
}

