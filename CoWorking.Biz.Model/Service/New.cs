using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Service
{
    public class New
    {
        public int ID { set; get; }
        public int CategoryServiceId { set; get; }
        public int OfficeId { set; get; }
        public string Name { set; get; }
        public string Decription { set; get; }
        public int Number { set; get; }
        public int Status { set; get; }
    }
}
