using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegritasTeste.Domain.Entities
{
    public class Customer : EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CustomerID { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Name { get; set; }
        [Column(TypeName = "VARCHAR")]
        [StringLength(4)]
        public string Age { get; set; }

    }
}
