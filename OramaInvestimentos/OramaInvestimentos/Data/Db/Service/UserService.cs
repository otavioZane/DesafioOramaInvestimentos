using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using OramaInvestimentos.Entities;
using OramaInvestimentos.Interfaces;
using OramaInvestimentos.Data.Entities;

namespace OramaInvestimentos.Data.Db.Client {
    public class UserService : IUserService {


        private readonly JwtConfig _jwtConfig;
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        private readonly ISalt _salt;
        private readonly IValidation _validation;
        private readonly IBankAccountRepository _bankAccountRepository;

        public UserService(
            ILogger logger,
            JwtConfig jwtConfig,
            IUserRepository userRepository,
            ISalt salt,
            IValidation validation,
            IBankAccountRepository bankAccountRepository

        ) {
            _jwtConfig = jwtConfig;
            _logger = logger;
            _userRepository = userRepository;
            _salt = salt;
            _validation = validation;
            _bankAccountRepository = bankAccountRepository;
        }

        public Response.Signin Signin(Request.Signin request) {
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfig.RsaPrivateKey)
            );
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var user = _userRepository.FindUser(request.email);

            if (user == null) {
                throw new CustomError(
                    "Usuário ou senha incorretos",
                    System.Net.HttpStatusCode.Unauthorized
                );
            }
            else {
                var bytePassword = Convert.FromBase64String(user.password);
                var byteSalt = Convert.FromBase64String(user.salt);
                if (!_salt.CheckHash(request.password, bytePassword, byteSalt)) {
                    throw new CustomError(
                        "Usuário ou senha incorretos",
                        System.Net.HttpStatusCode.Unauthorized
                    );
                }
            }

            var claims = new[]
            {
                new Claim(type: "customerID", value: user.customerID.ToString()),
            };

            var expires = DateTime.Now.AddHours(8);

            var token = new JwtSecurityToken(
                _jwtConfig.Issuer,
                _jwtConfig.Audience,
                claims,
                signingCredentials: credentials
            );
            var response = new Response.Signin() {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_at = new DateTimeOffset(expires).ToUnixTimeSeconds(),
            };

            return response;
        }

        public Response.Signup Signup(Request.Signup request) {

            if (!_validation.EMAIL(request.email)) {
                throw new CustomError("E-mail inválido", System.Net.HttpStatusCode.BadRequest);
            }

            if (_userRepository.FindUser(request.email) != null) {
                throw new CustomError(
                    "E-mail já utilizado",
                    System.Net.HttpStatusCode.BadRequest
                );
            }

            var salt = _salt.GetSalt();

            var hashedPassword = _salt.GetHash(request.password, salt);

            var check = _salt.CheckHash(request.password, hashedPassword, salt);

            var user = new CustomerParam() {
                email = request.email,
                name = request.name
            };

            Random r = new Random();
            int randNum = r.Next(1000000);
            string totp = randNum.ToString("D6");

            user.password = Convert.ToBase64String(hashedPassword);
            user.salt = Convert.ToBase64String(salt);

            var userDb = _userRepository.AddUser(user);

            var account = new BankAccountParam() { customerID = userDb.customerID, customer = userDb };

            var accountDb = _bankAccountRepository.AddAccount(account);

            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtConfig.RsaPrivateKey)
            );
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(type: "customerID", value: userDb.customerID.ToString()),
            };

            var expires = DateTime.Now.AddHours(8);

            var token = new JwtSecurityToken(
                _jwtConfig.Issuer,
                _jwtConfig.Audience,
                claims,
                signingCredentials: credentials
            );
            var response = new Response.Signup() {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expires_at = new DateTimeOffset(expires).ToUnixTimeSeconds()
            };
            return response;
        }
    }
}
