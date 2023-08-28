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
    }
}
