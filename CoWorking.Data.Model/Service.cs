using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Service")]
    public class Service
    {   
        [Key]
        public int ID { set; get; }     
        [ForeignKey("CategoryServiceId")]
        public int CategoryServiceId { set; get; }
        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        public string Name { set; get; }
        public string Decription { set; get; }
        public int Number { set; get; }
        public int Status { set; get; }
        public virtual CategoryService CategoryService { set; get; }
        public virtual Office Office { set; get; }

    }
}
