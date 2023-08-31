using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace OramaInvestimentos.Data.Entities {
    public class CustomerParam {

        [Column(TypeName = "BIGINT")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required]
        public string name { get; set; } 

        [Column(TypeName = "VARCHAR")]
        [StringLength(250)]
        [Required]
        public string email { get; set; } 

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        [Required]
        public string password { get; set; } 

        [Column(TypeName = "VARCHAR")]
        [StringLength(255)]
        public string salt { get; set; } 
        
        public BankAccountParam bankAccount { get; set; } 
    }
}
