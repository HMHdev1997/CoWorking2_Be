using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Customers
{
    public class ProcessUploadedFile
    {
        public IFormFile ImagePart { set; get; }
    }
}
