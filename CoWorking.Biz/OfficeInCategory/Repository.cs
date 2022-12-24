using AutoMapper;
using CoWorking.Biz.Model.OfficeInCategory;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.OfficeInCategory
{
    public class Repository :IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        public Repository(DomainDbContext context, IMapper mapper )
        {
            _context = context;
            _mapper = mapper;
        
        }

        public async Task<View> Create(New model)
        {
            var item = _mapper.Map<New, Data.Model.OfficeInCategory>(model);
            await _context.OfficeInCategories.AddRangeAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.OfficeInCategory, Model.OfficeInCategory.View>(item);
        }
    }
}
