namespace OramaInvestimentos.Data.Entities {
    public class BankAccount {

        public int accountID { get; set; }
        public int customerID { get; set; }
        public decimal balance { get; set; }
        public Client Client { get; set; } 
        public ICollection<FinancialTransaction> Transactions { get; set; }
    }
}
