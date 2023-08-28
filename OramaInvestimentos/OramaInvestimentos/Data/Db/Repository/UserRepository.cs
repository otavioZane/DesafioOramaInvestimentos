using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using static OramaInvestimentos.Data.Db.Repository.UserRepository;

namespace OramaInvestimentos.Data.Db.Repository {
    public class UserRepository {

        private readonly ILogger _logger;
        private readonly FinancialDbContext _dbContext;

        public UserRepository(ILogger logger, JwtConfig jwtConfig, FinancialDbContext dbContext) {

            _logger = logger;
            _dbContext = dbContext;
        }

        public Customer AddUser(Customer request) {
            var response = _dbContext.Customers.Add(request);
            _dbContext.SaveChanges();
            return request;
        }

        public Customer FindUser(string email) {
            var response = _dbContext.Customers
                .Where(u => u.email.Equals(email))
                .FirstOrDefault();
            return response;
        }

    }
}
