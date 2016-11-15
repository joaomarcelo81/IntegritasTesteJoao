using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegritasTeste.Domain.Entities
{
    public class Price : EntityBase
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PriceID { get; set; }
        public decimal Value { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime LastDate { get; set; }
        public long ProductID { get; set; }
        public virtual Product Product { get; set; }   
    }
}
