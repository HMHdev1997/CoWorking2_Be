using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Role")]
    public class Role
    {
        [Key]
        public int ID { set; get; }
        [MaxLength(256)]
        public string Name { set; get; }
        [MaxLength(50)]
        public string Position { set; get; }
        public double BaseSalary { set; get; }
        public virtual List<Staff> Staffs { set; get; }
    }
}
