using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Booking")]
    public class Booking

    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("UserId")]
        public int UserId { set; get; }
        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime StartTime { set; get; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime EndTime { set; get; }
        public double Total { set; get; }
        public DateTime CreateDate { set; get; } = DateTime.Now;
        public virtual User User { set; get; }
        public virtual Office Office { set; get; }      
        public virtual List<CategorySpace> Spaces { set; get; }
        public virtual List<BookingDetail> BookingDetails { set; get; }

    }
}
