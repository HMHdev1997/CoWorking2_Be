using System;

namespace CoWorking.Biz.Model.Customers
{
    public class View
    {

     
        public string ImagePart { set; get; }
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public DateTime? RegistrationDate { set; get; }
    }
}