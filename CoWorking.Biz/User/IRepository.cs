using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.User
{
    public interface IRepository
    {
        Task<Model.User.ViewUserCustomer> GetById(int id);
        Task<Model.User.View> GetUser(string email, string password, int phoneNumber);        
        Task<Model.User.View> CreateAync(Model.User.New model);

        Task<Model.User.View> GetUserInfo(int CutomerId);
        Task<int> DeleteAync(int id);
    }
}
