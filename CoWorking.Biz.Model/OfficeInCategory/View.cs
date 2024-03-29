﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.OfficeInCategory
{
    public class View
    {
        public int OfficeId { set; get; }
        public int CategoryOfficeId { set; get; }
        public virtual Offices.View Office { set; get; } = new Offices.View();
    }

    public class ViewDetail
    {
        public int ID { set; get; }
        public string NameOffice { set; get; }
        public int AreaId { set; get; }
        public int OfficeInCategoryId { set; get; }
        public string Address { set; get; }
        public string GenenalDecription { set; get; }
        public string Detail { set; get; }
        public string Tags { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public decimal Discount { set; get; }
    }

}
