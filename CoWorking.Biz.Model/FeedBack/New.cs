using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.FeedBack
{
    public class New
    {
           
        public int CustomerId { set; get; }
        public int OfficeId { set; get; }
        public string Message { set; get; }
        public int Votes { set; get; }
        public DateTime CreateDate { set; get; } = DateTime.Now;
    }
}
