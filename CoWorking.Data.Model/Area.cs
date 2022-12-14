using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Area")]
    public class Area
    {
        [Key]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string City { set; get; }
        [Required]
        [MaxLength(256)]
        public string District { set; get; }
        [Required]
        [MaxLength(256)]
        public string Street { set; get; }
        
        public virtual List<Data.Model.Office> Offices { set; get; }
    }
}
