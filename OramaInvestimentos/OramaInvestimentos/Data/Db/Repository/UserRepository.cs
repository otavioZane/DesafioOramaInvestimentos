using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using static OramaInvestimentos.Data.Db.Repository.UserRepository;

namespace OramaInvestimentos.Data.Db.Repository {
    public class UserRepository : IUserRepository {

        private readonly ILogger _logger;
        private readonly FinancialDbContext _dbContext;

        public UserRepository(ILogger logger, JwtConfig jwtConfig, FinancialDbContext dbContext) {

            _logger = logger;
            _dbContext = dbContext;
        }

        public CustomerParam AddUser(CustomerParam request) {
            var response = _dbContext.Customers.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public CustomerParam FindUser(string email) {
            var response = _dbContext.Customers
                .Where(u => u.email.Equals(email))
                .FirstOrDefault();
            return response;
        }

        public CustomerParam FindUserById(int customerID) {
            var response = _dbContext.Customers.Include(x => x.bankAccount).ThenInclude(x => x.transactions).ThenInclude(x => x.financialAsset)
                .Where(u => u.customerID.Equals(customerID))
                .FirstOrDefault();
            return response;
        }
    }
}
