using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("OfficeImage")]
    public class OfficeImage
    {   
        [Key]
        public int ID { set; get; }
        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        public string PartImage { set; get; }
        public string Caption { set; get; }
        public long FileSize { set; get; }    
        public virtual Office Office { set; get; }

    }
}
