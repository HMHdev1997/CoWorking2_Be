using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Data.Model
{   

    public class FeedBack
    {
        [Key]
        public int ID { set; get; }
        [ForeignKey("UserId")]
        public int UserId { set; get; }

        [ForeignKey("OfficeId")]
        public int OfficeId { set; get; }
        [StringLength(500)]
        public string Message { set; get; }
        public int Votes { set; get; }      
        public virtual User User { set; get; }
        public virtual Office Office { set; get; }
    }
}
