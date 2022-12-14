using AutoMapper;
using CoWorking.Biz.Model.CategoryService;
using CoWorking.Data.Access;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategoryService
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
            var item = _mapper.Map<New, Data.Model.CategoryService>(model);
            await _context.CategoryServices.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.CategoryService, View>(item);
        }
    }
}
