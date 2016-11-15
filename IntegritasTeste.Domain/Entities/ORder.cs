using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntegritasTeste.Domain.Common;

namespace IntegritasTeste.Domain.Entities
{
    public class Order: EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OrderID { get; set; }

        public Order()
        {
            if (DateTime == null)
                DateTime = DateTime.Now.CurrentDate();
        }

        public long CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IList<Product> Products { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Total { get; set; }
    }
}
