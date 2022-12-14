using CoWorking.Biz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Customer
{
    public interface IRepository
    {
        Task<Model.Customers.View> GetById(int id);
        Task<Model.Customers.View> CreateAync(Model.Customers.New model);
        Task DeleteAync(int id);
    }
}
