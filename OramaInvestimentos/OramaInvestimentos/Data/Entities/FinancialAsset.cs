using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OramaInvestimentos.Data.Entities {
    public class FinancialAsset {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assetID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string name { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal price { get; set; }
        public FinancialTransaction transaction { get; set; }
    }
}
