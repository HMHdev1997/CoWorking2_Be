using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoWorking.Data.Model
{
    [Table("User")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }

        [Required(ErrorMessage = "Phải có tên")]
        [MaxLength(256)]
        public string Name { set; get; }

        [Required(ErrorMessage = "phải nhập Email")]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { set; get; }
        
        public int PhoneNumbers { set; get; }

        [Required(ErrorMessage = "phải nhập Password")]
        public string Password { set; get; }

        public int Status { set; get; }
        public virtual List<Booking> Bookings { set; get; }
        public virtual List<FeedBack> FeedBacks { set; get; }
        public virtual  Customer Customer { set; get; } 
    }
}