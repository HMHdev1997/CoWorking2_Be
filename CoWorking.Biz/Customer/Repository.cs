using AutoMapper;
using CoWorking.Biz.Model.Customers;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CoWorking.Biz.Customer
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
     
        private readonly IWebHostEnvironment _enviromemt;

        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = environment;
        }

        public async Task<View> CreateAync(New model)
        {
            string uniqueFileName = ProcessUploadedFile(model);
            var user = new Data.Model.Customer
            {
                UserId = model.UserId,
                FullName = model.FullName,
                ImagePart = uniqueFileName,
                IdentifierCode = model.IdentifierCode,
                Address = model.Address,
                Gender = model.Gender,
                Age = model.Age,

            };
            await _context.Customers.AddAsync(user);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Customer, View>(user);
        }

        public async Task DeleteAync(int id)
        {
            var item = new Data.Model.Customer() { ID = id };
            _context.Customers.RemoveRange(item);
            await _context.SaveChangesAsync();
        }

        public async Task<View> GetById(int id)
        {
            var item =await _context.Customers.FirstOrDefaultAsync(q => q.ID == id);
            return _mapper.Map<Data.Model.Customer, View>(item);
        }

        public async Task<View> Update(Edit model)
        {
            var oldCustomer = await _context.Customers.FindAsync(model.Id);
            var item = _mapper.Map(model, oldCustomer );
            _context.Customers.Update(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Customer, Model.Customers.View>(item);
        }

        private string ProcessUploadedFile(New model)
        {
            string uniqueFileName = null;

            if (model.ImagePart != null)
            {
                string uploadsFolder = Path.Combine(_enviromemt.WebRootPath, "User");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePart.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePart.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }

     
    }
}