using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;

namespace OramaInvestimentos.Data.Db.Repository {
    public class BankAccountRepository : IBankAccountRepository {

        private readonly ILogger _logger;
        private readonly FinancialDbContext _dbContext;

        public BankAccountRepository(ILogger logger, JwtConfig jwtConfig, FinancialDbContext dbContext) {

            _logger = logger;
            _dbContext = dbContext;
        }

        public BankAccountParam AddAccount(BankAccountParam request) {
            var response = _dbContext.BankAccounts.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public BankAccountParam GetAccountByCustomer(int customerID) {
            var response = _dbContext.BankAccounts
                .Where(u => u.customerID.Equals(customerID))
                .FirstOrDefault();
            return response;
        }

        public BankAccountParam GetAccountbyId(int accountID) {
            var response = _dbContext.BankAccounts
                .Where(u => u.accountID.Equals(accountID))
                .FirstOrDefault();
            return response;
        }

        //    public  BankAccountParam AddFinancialTransaction(FinancialTransactionParam request) {
        //        var response = _dbContext.BankAccounts.Add(request);
        //        _dbContext.SaveChanges();
        //        return response;
        //    }
        //}
    }
}
