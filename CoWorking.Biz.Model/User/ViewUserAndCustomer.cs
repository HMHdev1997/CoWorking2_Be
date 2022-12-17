using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Model.User
{
    public class ViewUserAndCustomer
    {
        public string Name { set; get; }
        public string Email { set; get; }
        public int PhoneNumbers { set; get; }
        public virtual Customers.View Customers { set; get; }
    } 
}
