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
    public class Product : EntityBase
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<Price> Prices{get; set; }

        public long CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public Product()
        {
            Category = new Category();
            Prices = new List<Price>();
        }

        [NotMapped]
        public Price GetCurrentPrice
        {
            get
            {
                var price = Prices.FirstOrDefault(x => x.StartDate.CurrentDate() == DateTime.Now.CurrentDate());
                return price;
            }
        }
    }
}
