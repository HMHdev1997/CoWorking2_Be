using AutoMapper;
using CoWorking.Biz.Model.CategoryOffice;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategoryOffice
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
            var CategoryItem = _mapper.Map<New, Data.Model.CategoryOffice>(model);
            await _context.CategoryOffices.AddAsync(CategoryItem);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.CategoryOffice, Model.CategoryOffice.View>(CategoryItem);
        }

        public async Task<List<CategoryOfficeView>> GetAll()
        {
            var CategoryItem = await (from category in _context.CategoryOffices
                                      join p in _context.OfficeInCategories on category.ID equals p.CategoryOfficeId
                                      join office in _context.Offices on p.OfficeId equals office.ID
                                      select new CategoryOfficeView
                                      {
                                          Name = category.Name,
                                          Decription = category.Decription,
                                          OfficeInCategory = category.OfficeInCategories.Select(k => new Model.OfficeInCategory.View
                                          {
                                              CategoryOfficeId = k.CategoryOfficeId,
                                              OfficeId = k.OfficeId,
                                          }).ToList()

                                      })
                                      .ToListAsync();

            return CategoryItem;
        }

        public async Task<CategoryOfficeView> GetById(int id)
        {
        
            var categoryItem = await (from category in _context.CategoryOffices
                                     join p in _context.OfficeInCategories on category.ID equals p.CategoryOfficeId
                                     join office in _context.Offices on p.OfficeId equals office.ID
                                     where category.ID == id 
                                     select new CategoryOfficeView
                                     {  
                                         ID = category.ID,
                                         Name = category.Name,
                                         Decription = category.Decription,
                                         OfficeInCategory = category.OfficeInCategories.Select(p=> new Model.OfficeInCategory.View
                                         {
                                             CategoryOfficeId = p.CategoryOfficeId,
                                             OfficeId = p.OfficeId,
                                          
                                         }).ToList()
                                     }).FirstOrDefaultAsync();
            return categoryItem;
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