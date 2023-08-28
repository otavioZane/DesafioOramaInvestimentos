namespace OramaInvestimentos.Entities {
    public class JwtConfig {

        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string RsaPrivateKey { get; set; }
    }
}
