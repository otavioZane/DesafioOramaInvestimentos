using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Data.Entities {
    public class FinancialTransaction {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int transactionID { get; set; }
        public int accountID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(3)]
        public string type { get; set; }
        public int assetID { get; set; }
        [Column(TypeName = "DECIMAL")]
        public int quantity { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal totalValue { get; set; }
        public DateTime date { get; set; }
        public BankAccount bankAccount { get; set; } = new BankAccount(); 
        public FinancialAsset financialAsset { get; set; } = new FinancialAsset();
    }
}
