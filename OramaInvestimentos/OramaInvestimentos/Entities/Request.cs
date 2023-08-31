using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Entities {
    public class Request {

        public class Signin {

            [Required]
            public string email { get; set; }

            [Required]
            public string password { get; set; }

        }

        public class Signup {

            [Required]
            public string email { get; set; }

            [Required]
            public string password { get; set; }

            [Required]
            public string name { get; set; }

        }

        public class GetBalance {

           public int customerID { get; set; }
        }

        public class GetStatement {

            public int customerID { get; set; }
        }

        public class BuyFinancialAsset {

            public int quantity { get; set; }

            public int assetID  { get; set; }

        }       
    }
}
