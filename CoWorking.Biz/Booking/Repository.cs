using AutoMapper;
using CoWorking.Biz.Model.Bookings;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Booking
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;

        public Repository(DomainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<View> Create(New request)
        {
            var Booking = new Data.Model.Booking
            {
                UserId = request.UserId,
                OfficeId = request.OfficeId,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                Total = request.Total,
            };
            await _context.Bookings.AddAsync(Booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Booking, View>(Booking);
        }

        public async Task<View> GetById(int id)
        {
            var Booking = await _context.Bookings.Include(x => x.BookingDetails).FirstOrDefaultAsync(x => x.ID == id);
            return _mapper.Map<View>(Booking);
        }

        public async Task<List<View>> GetAll()
        {
            // var Booking = await _context.Bookings.Include(x => x.BookingDetails).ToListAsync();

            var Booking = await (from b in _context.Bookings

                                 select new CoWorking.Biz.Model.Bookings.View
                                 {
                                     ID = b.ID,
                                     UserId = b.UserId,
                                     OfficeId = b.OfficeId,
                                     StartTime = b.StartTime,
                                     EndTime = b.EndTime,
                                     Total = b.Total,
                                     CreatedDate = b.CreateDate,
                                     //   Name = category.Name,
                                     //   Decription = category.Decription,
                                     //   OfficeInCategory = category.OfficeInCategories.Select(k => new Model.OfficeInCategory.View
                                     //   {
                                     //       CategoryOfficeId = k.CategoryOfficeId,
                                     //       OfficeId = k.OfficeId,
                                     //   }).ToList()

                                 })
                                      .ToListAsync();
            return Booking;
        }

        public async Task<List<View>> GetBookingbyUserId(int id)
        {
            // var Booking = await _context.Bookings.Include(x => x.BookingDetails).ToListAsync();

            var Booking = await (from b in _context.Bookings
                                 where b.UserId == id   
                                 select new CoWorking.Biz.Model.Bookings.View
                                 {
                                     ID = b.ID,
                                     UserId = b.UserId,
                                     OfficeId = b.OfficeId,
                                     StartTime = b.StartTime,
                                     EndTime = b.EndTime,
                                     Total = b.Total,
                                     CreatedDate = b.CreateDate,
                                     // BookingDetail = b.BookingDetails

                                 })
                                      .ToListAsync();
            return Booking;
        }
    }
}
