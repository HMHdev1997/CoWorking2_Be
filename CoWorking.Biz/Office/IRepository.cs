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
        Task<Model.Offices.View> CreateAync(Model.Offices.New model);
       
    }
}
