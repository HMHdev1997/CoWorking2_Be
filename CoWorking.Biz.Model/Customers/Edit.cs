using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Customers
{
    public class Edit :ProcessUploadedFile
    {
        public int ID { set; get; }
        public string Password { set; get; }
        public string Fullname { set; get; }      
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public int PhoneNumbers { set; get; }
        public string Email { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public DateTime? RegistrationDate { set; get; }
    }
}
