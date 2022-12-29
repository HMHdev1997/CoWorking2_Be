using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Bookings
{
    public class View
    {
        public int ID { set; get; }
        public int CustomerId { set; get; }
        public int OfficeId { set; get; }
        public DateTime? StartTime { set; get; }
        public DateTime? EndTime { set; get; }
        public double Total { set; get; }
        public DateTime? CreatedDate { set; get; }
        public virtual List<Model.BookingDetail.View> BookingDetail { set; get; } = new List<BookingDetail.View>();
    }
}
