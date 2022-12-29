using Microsoft.AspNetCore.Http;
using System;

namespace CoWorking.Biz.Model.Customers
{
    public class New
    {
  
        public int UserId { set; get; }
        public string FullName { set; get; }
        public int IdentifierCode { set; get; }
        public string Address { set; get; }
        public string Gender { set; get; }
        public int Age { set; get; }
        public IFormFile ImagePart { set; get; }
        public DateTime? DateOfBirth { set; get; }
      
    }
}