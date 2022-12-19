using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   
    [Table("Office")]
    public class Office
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [ForeignKey("AreaId")]
        public int AreaId { set; get; }
      
        [MaxLength(256)]
        public string NameOffice { set; get; }
        [MaxLength(256)]
        public string Address { set; get; }
        [MaxLength(500)]
        public string GenenalDecription { set; get; }
        public string Detail { set; get; }
        public string Tags { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public decimal Discount { set; get; }
        public long Latitude { set; get; }
        public long Longitude { set; get; }
        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public string ModifiedBy { set; get; }

        public virtual Area Area { set; get; }
        public virtual List<OfficeInCategory> OfficeInCategories { set; get; }
        public virtual List<Booking> Bookings { set; get; }
        public virtual List<Space> Spaces { set; get; }
        public virtual List<OfficeImage> OfficeImages { set; get; }
        public virtual List<FeedBack> FeedBacks { set; get; }
        public virtual List<Manager> Managers { set; get; }
        public virtual List<Service> Services { set; get; }
    }
}
