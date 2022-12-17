using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.User;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
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
            var userNew = _context.Users.FirstOrDefault(x => x.Email == model.Email || x.PhoneNumbers == model.PhoneNumbers);
            if (userNew == null)
            {
                var item = _mapper.Map<New, Data.Model.User>(model);
                await _context.Users.AddAsync(item);
                await _context.SaveChangesAsync();
                return _mapper.Map<Data.Model.User, View>(item);
            }
            return _mapper.Map<Data.Model.User, View>(null);
        }

        public async Task DeleteAync(int id)
        {
            var item =await _context.Users.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
           _context.Users.RemoveRange(item);
            await _context.SaveChangesAsync();
        }

        public async Task<ViewUserAndCustomer> GetById(int id)
        {
            var user =await  _context.Users.Include(x=>x.Customer).FirstOrDefaultAsync(x => x.Id==id);
            return _mapper.Map<Data.Model.User, Model.User.ViewUserAndCustomer>(user);

        }

        public async Task<ViewUserAndCustomer> GetUser(string email, string password, int phoneNumber)
        {
            var Login = await _context.Users.FirstOrDefaultAsync(x => x.Email == email || x.PhoneNumbers == phoneNumber);
            if(Login == null)
            {
                return null;
            }
            else
            {
                if(Login.Password == password)
                {
                    return _mapper.Map<Data.Model.User, Model.User.ViewUserAndCustomer>(Login);
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
