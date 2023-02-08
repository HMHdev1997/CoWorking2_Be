using AutoMapper;
using CoWorking.Biz.Model.BookingDetail;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.BookingDetail
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
            var BookingDetail = new Data.Model.BookingDetail
            {
                BookingId = request.BookingId,
                Name = request.Name,
                Number = request.Number,
                Price = request.Price,
                Note = request.Note,
                SeatPosition = request.SeatPosition,
                StartTime = request.StartTime??DateTime.Now,
                EndTime = request.EndTime??DateTime.Now,
                PaymentStatus = request.PaymentStatus,
            };

            await _context.BookingDetails.AddAsync(BookingDetail);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.BookingDetail, View>(BookingDetail);
        }

        public async Task<View> GetById(int id)
        {
            var BookingDetail = await _context.BookingDetails.FirstOrDefaultAsync(x => x.BookingId == id);
            return _mapper.Map<View>(BookingDetail);
        }

        public async Task<List<View>> GetAll()
        {
            // var Booking = await _context.Bookings.Include(x => x.BookingDetails).ToListAsync();

            var BookingDetail = await (from b in _context.BookingDetails

                                       select new CoWorking.Biz.Model.BookingDetail.View
                                       {
                                           ID = b.ID,
                                           BookingId = b.BookingId,
                                           Name = b.Name,
                                           Number = b.Number,
                                           Price = b.Price,
                                           Note = b.Note,
                                           SeatPosition = b.SeatPosition,
                                           StartTime = b.StartTime,
                                           EndTime = b.EndTime,
                                           PaymentStatus = b.PaymentStatus,
                                       })
                                      .ToListAsync();
            return BookingDetail;
        }

        public async Task<List<View>> GetBookingbyUserId(int id)
        {
            // var Booking = await _context.Bookings.Include(x => x.BookingDetails).ToListAsync();

            var BookingDetail = await (from b in _context.BookingDetails
                                       where b.BookingId == id
                                       select new CoWorking.Biz.Model.BookingDetail.View
                                       {
                                           ID = b.ID,
                                           //  UserId = b.UserId,
                                           //  OfficeId = b.OfficeId,
                                           //  StartTime = b.StartTime,
                                           //  EndTime = b.EndTime,
                                           //  Total = b.Total,
                                           //  CreatedDate = b.CreateDate,
                                           // BookingDetail = b.BookingDetails

                                       })
                                      .ToListAsync();
            return BookingDetail;
        }

        public Task<Model.Bookings.View> Create(Model.Bookings.New request)
        {
            throw new NotImplementedException();
        }

        // Task<Model.Bookings.View> IRepository.GetById(int id)
        // {
        //     throw new NotImplementedException();
        // }

        // Task<List<Model.Bookings.View>> IRepository.GetAll()
        // {
        //     throw new NotImplementedException();
        // }

        // Task<List<Model.Bookings.View>> IRepository.GetBookingbyUserId(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
