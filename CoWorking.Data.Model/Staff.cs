using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Staff")]
    public class Staff
    {

        [Key]
        public int ID { set; get; }
        [ForeignKey("RoleId")]
        public int RoleId { set; get; }
        [MaxLength(100)]
        public string Account { set; get; }
        [MaxLength(50)]
        public string Name { set; get; }
        [MaxLength(100)]
        public string Fullname { set; get; }
        public int IdentifierCode { set; get; }
        [MaxLength(256)]
        public string Address { set; get; }
        public int PhoneNumbers { set; get; }
        [MaxLength(256)]
        public string Email { set; get; }
        [MaxLength(5)]
        public string Gender { set; get; }
        public int Age { set; get; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? DateOfBirth { set; get; }
        public DateTime? DateOfWork { set; get; }
        public virtual Role Role { set; get; }
        public virtual List<Manager> Managers { set; get; }
    }
}
