using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{
    [Table("Space")]
    public class Space
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        [ForeignKey("CategorySpaceId")]
        public int CategorySpaceId { set; get; }
        public int LocationSpace { set; get; }
        public int Staus { set; get; }
        public double Price { set; get; }
        public virtual Office Office { set; get; }
        public virtual CategorySpace CategorySpace {set; get;}
    }
}
