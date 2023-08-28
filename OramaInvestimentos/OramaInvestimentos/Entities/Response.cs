namespace OramaInvestimentos.Entities {
    public class Response {

        public class Confirm {

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
    }
}

