using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.BookingDetail
{
    public interface IRepository
    {
        Task<Model.BookingDetail.View> Create(Model.BookingDetail.New request);
        Task<Model.BookingDetail.View> GetById(int id);
        Task<List<Model.BookingDetail.View>> GetAll();
        Task<List<Model.BookingDetail.View>> GetBookingbyUserId(int id);
    }
}
