using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("CategoryService")]
    public class CategoryService
    {   
        [Key]
        public int ID { set; get; } 
        [MaxLength(256)]
        public string Name { set; get; }
        public string Decription { set; get; }
        public List<Service> Services { set; get; }
       
    }
}
