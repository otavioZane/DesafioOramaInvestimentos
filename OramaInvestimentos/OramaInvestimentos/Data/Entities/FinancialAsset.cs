namespace OramaInvestimentos.Data.Entities {
    public class FinancialAsset {

        public int AssetID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<FinancialTransaction> Transactions { get; set; }
    }
}
