using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;

namespace OramaInvestimentos.Data.Db.Service {
    public class BankAccountService : IBankAccountService {

        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly IBankAccountRepository _bankAccountRepository;

        public BankAccountService(
            ILogger logger,
            IUserRepository userRepository,
            IBankAccountRepository bankAccountRepository

        ) {
            _logger = logger;
            _userRepository = userRepository;
            _bankAccountRepository = bankAccountRepository;
        }

        public Response.GetBalance GetBalance(Request.GetBalance request) {

            var account = _userRepository.FindUserById(request.customerID);
            var response = new Response.GetBalance() { balance = account.bankAccount.balance };

            return response;
        }

        public Response.GetStatement GetStatement(Request.GetStatement request) {

            var account = _userRepository.FindUserById(request.customerID);
            var statements = new List<Response.GetStatement.Statement>();
            if (account.bankAccount != null) {
                foreach (var statement in account.bankAccount.transactions) {

                    statements.Add(new Response.GetStatement.Statement() {
                        transactionID = (int)statement.transactionID,
                        type = statement.type,
                        date = statement.date,
                        totalValue = statement.totalValue,
                        financialAsset = statement.financialAsset
                    }); ;
                }
            }
            return new Response.GetStatement() {
                statements = statements
            };
        }
    }
}

