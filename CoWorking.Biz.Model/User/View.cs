using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.User
{
    public class View
    {
        public int ID { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public int PhoneNumbers { set; get; }
        public string Password { set; get; }
        public double Point { set; get; }
        public Biz.Model.Customers.View User { set; get; } = new Customers.View();
    }

}
