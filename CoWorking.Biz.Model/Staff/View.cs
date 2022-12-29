using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.Staff
{
    public class View
    {
        public int ID { set; get; }   
        public int RoleId { set; get; }
        public string Account { set; get; }
        public string Name { set; get; }
        public string Fullname { set; get; }
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public int PhoneNumbers { set; get; }
        public string Email { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime? DateOfBirth { set; get; }
        public DateTime? DateOfWork { set; get; }
    }
}
