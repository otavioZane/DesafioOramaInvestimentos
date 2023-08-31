using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Data.Entities {
    public class BankAccountParam {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountID { get; set; }
        public int customerID { get; set; }

        [Column(TypeName = "DECIMAL")]       
        public decimal balance { get; set; }
        public CustomerParam customer { get; set; } = new CustomerParam(); 
        public virtual ICollection<FinancialTransactionParam> transactions { get; set; } = new List<FinancialTransactionParam>();
    }
}
