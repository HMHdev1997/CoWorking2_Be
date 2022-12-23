using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.User
{
    public class CreateUserInfoRequest
    {   
        public int ID { set; get; } 
        public string FullName { set; get; }
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public DateTime RegistrationDate { set; get; } = DateTime.Now;
    }
}
