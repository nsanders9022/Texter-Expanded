using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Texter.Models
{
    [Table("Phones")]
    public class Phone
    {
        [Key]
        public int PhoneId { get; set; }
        public string PhoneType { get; set; }
        public string Number { get; set; }
        public string ContactName { get; set; }
        public virtual Contact Contact { get; set; }

        public Phone() { }
    }
}
