using AutoMapper;
using CoWorking.Biz.Model.CategoryOffice;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategoryOffice
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
            var CategoryItem = _mapper.Map<New, Data.Model.CategoryOffice>(model);
            await _context.CategoryOffices.AddAsync(CategoryItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.CategoryOffice, Model.CategoryOffice.View>(CategoryItem);
        }

        public async Task<List<CategoryOfficeView>> GetAll()
        {
            var CategoryItem = await _context.CategoryOffices.Include(x => x.OfficeInCategories).ToListAsync();
            return _mapper.Map<List<Data.Model.CategoryOffice>, List<CategoryOfficeView>>(CategoryItem);
           
        }

        public async Task<View> Update(Edit model)
        {
            var oldCategoryOffice = await _context.CategoryOffices.FindAsync(model.ID);
            var newCategoryOffice = _mapper.Map(model, oldCategoryOffice);
            _context.CategoryOffices.UpdateRange(newCategoryOffice);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.CategoryOffice, View>(newCategoryOffice);
        }


    }
}
