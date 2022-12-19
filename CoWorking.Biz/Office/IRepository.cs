using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Office
{
    public interface IRepository
    {
        Task<int> AddImage(int OfficeId, Model.OfficeImages.New request);
        Task<Model.Offices.View> CreateAync(Model.Offices.OfficeCreateRequest request);
        Task<Model.Offices.View> GetById(int id);
    }
}
