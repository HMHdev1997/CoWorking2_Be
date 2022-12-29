using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Staff
{
    public interface IRepository
    {
        Task<Model.Staff.View> CreateAsync(Model.Staff.New request);
    }
}
