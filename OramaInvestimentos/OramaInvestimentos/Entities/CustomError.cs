using System.Net;

namespace OramaInvestimentos.Entities {
    public class CustomError : Exception {

        public class Error {
            public string message;
        };
        public Error error;
        public HttpStatusCode status;

        public CustomError(string _message, HttpStatusCode _status)
            : base("CustomError IncluiChave") {
            error = new Error() { message = _message };
            status = _status;
        }
    }
}
