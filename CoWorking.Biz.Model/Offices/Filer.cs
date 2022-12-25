using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Offices
{
    public class Filer
    {
        public int ID { set; get; }
        public string NameOffice { set; get; }
        public int OfficeInCategoryId { set; get; }
        public string Address { set; get; }
        public string GenenalDecription { set; get; }
        public string Detail { set; get; }
        public string Tags { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public decimal Discount { set; get; }
        public virtual List<Model.OfficeImages.View> OfficeImage { set; get; } = new List<OfficeImages.View>();
        public virtual List<Model.Space.View> Space { set; get; } = new List<Space.View>();
    }
}
