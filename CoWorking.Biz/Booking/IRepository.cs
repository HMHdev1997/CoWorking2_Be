using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Booking
{
    public interface IRepository
    {
        public Task<Model.Bookings.View> Create(Model.Bookings.New request);
    }
}
