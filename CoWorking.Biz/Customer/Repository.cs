using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.Customers;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics; 

namespace CoWorking.Biz.Customer
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStorageService _storageService;
        private readonly IWebHostEnvironment _enviromemt;
        private const string USER_CONTENT_FOLDER_NAME = "Image/User";

        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = environment;
            _storageService = storageService;
        }

        public async Task<View> CreateAync(New model)
        {
            var user = new Data.Model.Customer()
            {
                UserId = model.UserId,
                FullName = model.FullName,
                IdentifierCode = model.IdentifierCode,
                Address = model.Address,
                Gender = model.Gender,
                Age = model.Age,
            };
            if (model.ImagePart != null)
            {
                await this.SaveFile(model.ImagePart);
            }

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

        public async Task<View> GetById(int UserId)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(q => q.UserId == UserId);
            return _mapper.Map<Data.Model.Customer, View>(item);
        }

        public async Task<View> Update(Edit model)
        {
            Debug.WriteLine(model.Id);
            var Customer = await _context.Customers.AsNoTracking().FirstOrDefaultAsync(q => q.UserId == model.Id);
            if (Customer == null)
            {
                var user = new Data.Model.Customer()
                {
                    UserId = model.Id,
                    FullName = model.Fullname,
                    IdentifierCode = model.IdentifierCode,
                    Address = model.Address,
                    Gender = model.Gender,
                    Age = model.Age,
                };
                if (model.ImagePart != null)
                {
                    await this.SaveFile(model.ImagePart);
                }

                await _context.Customers.AddAsync(user);
                await _context.SaveChangesAsync();
                return _mapper.Map<Data.Model.Customer, View>(user);
            }
            Customer.FullName = model.Fullname;
            Customer.IdentifierCode = model.IdentifierCode;
            Customer.Address = model.Address;
            Customer.Gender = model.Gender;
            Customer.Age = model.Age;
            Customer.DateOfBirth = model.DateOfBirth;
            if (model.ImagePart != null)
            {
                Customer.ImagePart = await this.SaveFile(model.ImagePart);
            }

            _context.Customers.UpdateRange(Customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<Data.Model.Customer, View>(Customer);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }
    }
}