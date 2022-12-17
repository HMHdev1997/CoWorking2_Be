using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.User
{
    public interface IRepository
    {
        Task<Model.User.ViewUserAndCustomer> GetById(int id);
        Task<Model.User.ViewUserAndCustomer> GetUser(string email, string password, int phoneNumber);

        Task<Model.User.View> CreateAync(Model.User.New model);
        Task DeleteAync(int id);
    }
}
