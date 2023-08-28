using OramaInvestimentos.Entities;

namespace OramaInvestimentos.Interfaces {
    public interface IUserService {
     
       Response.Signin Signin(Request.Signin request);
       Response.Signup Signup(Request.Signup request);

    }
}
