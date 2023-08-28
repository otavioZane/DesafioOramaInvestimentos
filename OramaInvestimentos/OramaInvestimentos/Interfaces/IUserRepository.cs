using OramaInvestimentos.Data.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IUserRepository {

        public Customer AddUser(Customer request);

        public Customer FindUser(string email);

    }
}
