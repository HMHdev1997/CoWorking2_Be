using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.FeedBack
{
    public interface IRepository
    {
        Task<Model.FeedBack.View> CreateAsync(Model.FeedBack.New request);
        Task<Model.FeedBack.View> Update(Model.FeedBack.Edit request);
        Task Delete(int id);
    }
}
