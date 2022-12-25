using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.CategoryOffice
{
    public class CategoryOfficeView
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Decription { set; get; }
        public virtual List<OfficeInCategory.View> OfficeInCategory { set; get;} = new List<OfficeInCategory.View>();         

    }

}
