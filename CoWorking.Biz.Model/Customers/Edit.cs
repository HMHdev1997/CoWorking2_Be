using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Customers
{
    public class Edit :ProcessUploadedFile
    {
        public int Id { set; get; }
        public string Fullname { set; get; }      
        public int IdentifierCode { set; get; }
        public string Address { set; get; }   
        public string Gender { set; get; }
        public int Age { set; get; }
        public double Point { set; get; }
        public DateTime? DateOfBirth { set; get; }
      
    }
}
