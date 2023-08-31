using OramaInvestimentos.Data.Entities;

namespace OramaInvestimentos.Entities {
    public class Response {

        public class Sucess {
            public string message { get; set; }
        }

        public class Signin {

            public string token { get; set; }
            public long expires_at { get; set; }

        }

        public class Signup {
            public string token { get; set; }
            public long expires_at { get; set; }
        }

        public class GetBalance {

            public decimal balance { get; set; }
        }

        public class GetStatement {

            public List<Statement> statements { get; set; }

            public class Statement {

                public long? transactionID { get; set; }

                public string type { get; set; }

                public decimal totalValue { get; set; }

                public DateTime date { get; set; }

                public FinancialAssetParam financialAsset { get; set; }
            }
        }

        public class GetFinancialAssets {

            public List<FinancialAssetParam> assets { get; set; }
        }    
    }
}

