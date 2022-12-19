using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Offices
{
    public class OfficeCreateRequest
    {
    
  
        public int AreaId { set; get; }
        public string NameOffice { set; get; }
        public string Address { set; get; }
        public string GenenalDecription { set; get; }
        public string Detail { set; get; } 
        public string Tags { set; get; }
        public bool? HotFlag { set; get; }
        public int? ViewCount { set; get; }
        public decimal Discount { set; get; }
        public long Latitude { set; get; }
        public long Longitude { set; get; }
        public DateTime? CreateDate { set; get; }
        public string CreateBy { set; get; }
        public DateTime? ModifiedDate { set; get; }
        public string ModifiedBy { set; get; }
        public IFormFile ThumbnailImage { set; get; }
        
    }
}
