using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Manager")]
    public class Manager
    {   

        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        [ForeignKey("StaffId")]
        public int StaffId { set; get; }
        public virtual Office Office { set; get; }
        public virtual Staff Staff { set; get; }
    }
}
