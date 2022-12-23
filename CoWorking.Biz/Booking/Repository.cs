﻿using AutoMapper;
using CoWorking.Biz.Model.Bookings;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Booking
{
    public class Repository: IRepository
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
            var Booking = _mapper.Map<New, Data.Model.Booking>(request);
            await _context.Bookings.AddAsync(Booking);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Booking, View>(Booking);
        }
    }
}
