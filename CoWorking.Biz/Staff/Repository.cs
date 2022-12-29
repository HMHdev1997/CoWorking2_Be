using AutoMapper;
using CoWorking.Biz.Model.Staff;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Staff
{
    public class Repository :IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;

        public Repository(DomainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<View> CreateAsync(New request)
        {
            var item = _mapper.Map<New, Data.Model.Staff>(request);
            await _context.Staffs.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Staff, View>(item);
        }

       
    }
}
