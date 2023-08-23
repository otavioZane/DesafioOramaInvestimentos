namespace OramaInvestimentos.Data.Entities {
    public class FinancialTransaction {
        public int TransactionID { get; set; }
        public int AccountID { get; set; }
        public string Type { get; set; }
        public int AssetID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalValue { get; set; }
        public DateTime Date { get; set; }
        public BankAccount BankAccount { get; set; } // Navigation property
        public FinancialAsset FinancialAsset { get; set; } // Navigation property
    }
}
