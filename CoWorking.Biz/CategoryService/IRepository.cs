using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategoryService
{
    public interface IRepository
    {
        Task<Model.CategoryService.View> CreateAync(Model.CategoryService.New model);
    }
}
