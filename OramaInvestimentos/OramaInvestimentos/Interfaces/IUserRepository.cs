using OramaInvestimentos.Data.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IUserRepository {

        public CustomerParam AddUser(CustomerParam request);

        public CustomerParam FindUser(string email);

        public CustomerParam FindUserById(int customerID);

    }
}
