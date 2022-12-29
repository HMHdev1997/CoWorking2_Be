using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.FeedBack
{
    public class Edit
    {
        public int ID { set; get; }
        public int CustomerId { set; get; }      
        public string Message { set; get; }
        public int Votes { set; get; }
    }
}
