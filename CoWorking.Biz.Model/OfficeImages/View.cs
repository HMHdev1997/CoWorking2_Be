using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.OfficeImages
{
    public class View
    {
        public int ID { set; get; }
        public int OfficeId { set; get; }
        public string PartImage { set; get; }
        public string Caption { set; get; }
        public long FileSize { set; get; }
    }
}
