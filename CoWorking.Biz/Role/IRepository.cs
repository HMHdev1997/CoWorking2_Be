using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Role
{
    public interface IRepository
    {
        Task<Model.Role.View> CreateAsync(Model.Role.New request);
    }
}
