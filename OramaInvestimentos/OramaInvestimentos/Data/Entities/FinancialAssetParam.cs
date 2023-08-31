using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OramaInvestimentos.Data.Entities {
    public class FinancialAssetParam {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int assetID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        public string name { get; set; }

        [Column(TypeName = "DECIMAL")]
        public decimal price { get; set; }
        [JsonIgnore]
        public virtual ICollection<FinancialTransactionParam> transactions { get; set; }
    }
}
