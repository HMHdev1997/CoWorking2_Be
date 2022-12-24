using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.CategoryOffice
{
    public class CategoryOfficeView
    {
        public string Name { set; get; }
        public string Decription { set; get; }
        public virtual List<Model.OfficeInCategory.View> OfficeInCategory { set; get; }


    }
}
