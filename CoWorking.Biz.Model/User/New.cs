using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.User
{
    public class New
    {   
        public string Name { set; get; }
        [DataType(DataType.EmailAddress)]
        public string Email { set; get; }
        public int PhoneNumbers { set; get; }
        public string Password { set; get; }
    }
}
