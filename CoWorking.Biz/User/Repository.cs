using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.User;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.User
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

        public async Task<View> CreateAync(New model)
        {   
            
            var item = _mapper.Map<New, Data.Model.User>(model);
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.User, View>(item);
        }
    }
}
