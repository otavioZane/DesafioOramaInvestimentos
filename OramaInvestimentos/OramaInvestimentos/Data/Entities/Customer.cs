using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OramaInvestimentos.Data.Entities {
    public class Customer {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required]
        public string name { get; set; } = String.Empty;

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required]
        public string email { get; set; } = String.Empty;

        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Required]
        public string password { get; set; } = String.Empty;

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string salt { get; set; } = String.Empty;
        
        public BankAccount bankAccount { get; set; } = new BankAccount();
    }
}
