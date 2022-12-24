using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.OfficeInCategory
{
    public interface IRepository
    {
        Task<Model.OfficeInCategory.View> Create(Model.OfficeInCategory.New model);
    }
}
