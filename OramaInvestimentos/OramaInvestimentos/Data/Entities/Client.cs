namespace OramaInvestimentos.Data.Entities {
    public class Client {

        public int customerID { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; } // Hashed password should be stored here
        public ICollection<BankAccount> bankAccounts { get; set; }
    }
}
