using AutoMapper;
using CoWorking.Biz.Model.Area;
using CoWorking.Data.Access;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Area
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

        public async Task<View> CreateAync(New model)
        {
            var item = _mapper.Map<New, Data.Model.Area>(model);
            await _context.Areas.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Area, View>(item);
        }
    }
}
