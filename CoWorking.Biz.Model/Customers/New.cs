using System;

namespace CoWorking.Biz.Model.Customers
{
    public class New : ProcessUploadedFile
    {
        public int ID { set; get; }
        public string FullName { set; get; }
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public DateTime? DateOfBirth { set; get; }
        public DateTime? RegistrationDate { set; get; }
    }
}