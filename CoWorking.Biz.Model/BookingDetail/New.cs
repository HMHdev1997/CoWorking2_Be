using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.BookingDetail
{
    public class New
    {
        public int ID { set; get; }
        public int BookingId { set; get; }
        public string Name { set; get; }
        public int Number { set; get; }
        public double Price { set; get; }
        public string Note { set; get; }
        public string SeatPosition { set; get; }
        public DateTime? StartTime { set; get; }
        public DateTime? EndTime { set; get; }
        public int PaymentStatus { set; get; }
        public DateTime? CreaetDate { set; get; }
        public string CreateBy { set; get; }
    }
}
