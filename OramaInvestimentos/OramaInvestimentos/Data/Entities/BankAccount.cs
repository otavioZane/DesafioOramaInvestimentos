using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Data.Entities {
    public class BankAccount {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int accountID { get; set; }
        public int customerID { get; set; }

        [Column(TypeName = "DECIMAL")]       
        public decimal balance { get; set; }
        public Customer customer { get; set; } = new Customer(); 
        public ICollection<FinancialTransaction> transactions { get; set; } = new List<FinancialTransaction>();
    }
}
