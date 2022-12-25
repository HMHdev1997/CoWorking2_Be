using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategoryOffice
{
    public interface IRepository
    {
        Task<Model.CategoryOffice.View> CreateAync(Model.CategoryOffice.New model);
        Task<List<Model.CategoryOffice.CategoryOfficeView>> GetAll();
        Task<Model.CategoryOffice.CategoryOfficeView> GetById(int id);
        Task<Model.CategoryOffice.View> Update(Model.CategoryOffice.Edit model);
            

    }
}
