using OramaInvestimentos.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IBankAccountService {

        Response.GetBalance GetBalance(Request.GetBalance request);
        Response.GetStatement GetStatement(Request.GetStatement request);
    }     
}
