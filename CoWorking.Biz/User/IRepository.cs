using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.User
{
    public interface IRepository
    {
        Task<Model.User.ViewUserAndCustomer> GetUser(int id);
        Task<Model.User.View> CreateAync(Model.User.New model);
        Task DeleteAync(int id);
    }
}
