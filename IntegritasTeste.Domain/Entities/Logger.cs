using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegritasTeste.Domain.Entities
{
    public class Logger : EntityBase
    {
        public Logger()
        {
            if (DateTime == DateTime.MinValue)
                DateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LoggerID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(400)]
        public string Description { get; set; }

        [StringLength(500)]
        public string Message { get; set; }

        [StringLength(5000)]
        public string Stacktrace { get; set; }

        public DateTime DateTime { get; set; }


    }
}
