using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoWorking.Data.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("UserId")]
        public int UserId { set; get; }
        [Required]
        [MaxLength(256)]
        public string FullName { set; get; }
        public string ImagePart { set; get; }
        public double Point { set; get; }
        public int IdentifierCode { set; get; }

        [MaxLength(256)]
        public string Address { set; get; }

        [MaxLength(5)]
        public string Gender { set; get; }

        public int Age { set; get; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? DateOfBirth { set; get; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? RegistrationDate { set; get; }
        public virtual User User { set; get; }

        
     
    }
}