using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Area
{
    public interface IRepository
    {
        Task<Model.Area.View> CreateAync(Model.Area.New model);
    }
}
