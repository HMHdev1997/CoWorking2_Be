using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{
    [Table("OfficeInCategory")]
    public class OfficeInCategory
    {   
  
        [ForeignKey("CategoryOfficeId")]
        public int CategoryOfficeId {set; get;}
        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }

        public virtual CategoryOffice CategoryOffice { set; get; }
        public virtual Office Office { set; get; }
    }
}
