using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Data.Entities {
    public class FinancialTransactionParam {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? transactionID { get; set; }
        public int accountID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(4)]
        public string type { get; set; }
        public int assetID { get; set; }
        [Column(TypeName = "DECIMAL")]
        public int quantity { get; set; }
        [Column(TypeName = "DECIMAL")]
        public decimal totalValue { get; set; }
        public DateTime date { get; set; }
        public virtual BankAccountParam bankAccount { get; set; } 
        public FinancialAssetParam financialAsset { get; set; } 
    }
}
