using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Booking
{
    public interface IRepository
    {
        Task<Model.Bookings.View> Create(Model.Bookings.New request);
        Task<Model.Bookings.View> GetById(int id);
        Task<List<Model.Bookings.View>> GetAll();
        Task<List<Model.Bookings.View>> GetBookingbyUserId(int id);
    }
}
