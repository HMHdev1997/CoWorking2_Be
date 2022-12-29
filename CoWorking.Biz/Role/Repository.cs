using AutoMapper;
using CoWorking.Biz.Model.Role;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.Role
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
            var item = _mapper.Map<New, Data.Model.Role>(request);
            await _context.Roles.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Role, View>(item);
        }
    }
}
