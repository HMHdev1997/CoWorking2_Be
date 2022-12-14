using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   

    [Table("CategorySpace")]
    public class CategorySpace
    {   
        [Key]
        public int ID { set; get; }
        public string Name { set; get; }
        [StringLength(500)]
        public string Decription { set; get; }
        public double Price { set; get; }
        public virtual List<Space> Spaces { set; get; }
      
    }
}
