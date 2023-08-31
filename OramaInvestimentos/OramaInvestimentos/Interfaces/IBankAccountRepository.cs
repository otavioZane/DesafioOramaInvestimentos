using Microsoft.EntityFrameworkCore;
using OramaInvestimentos.Data.Db.Repository;
using OramaInvestimentos.Data.Entities;
using OramaInvestimentos.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IBankAccountRepository {

        BankAccountParam AddAccount(BankAccountParam request);
        BankAccountParam GetAccountByCustomer(int customerID);
        BankAccountParam GetAccountbyId(int accountID);
        //BankAccountParam AddFinancialTransaction(FinancialTransactionParam request);
    }
}
