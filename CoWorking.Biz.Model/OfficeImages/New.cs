using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.OfficeImages
{
    public class New 
    {      
        public int OfficeId { set; get; }
        public IFormFile ImagePart { set; get; }
        public string Caption { set; get; }
        public long FileSize { set; get; }

    }
}
