using CoWorking.Biz.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Customer
{
    public interface IRepository
    {
        Task<Model.Customers.View> GetById(int UserId);
        Task<Model.Customers.View> CreateAync(Model.Customers.New model);
        Task<Model.Customers.View> Update(Model.Customers.Edit model);
        
        Task DeleteAync(int id);
    }
}
