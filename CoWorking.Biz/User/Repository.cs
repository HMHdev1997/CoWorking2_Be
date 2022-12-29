using AutoMapper;
using CoWorking.Biz.Model.User;
using CoWorking.Data.Access;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoWorking.Biz.User
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
            var userNew = _context.Users.FirstOrDefault(x => x.Email == model.Email || x.PhoneNumbers == model.PhoneNumbers);
            if (userNew != null)
            {
                throw new Model.CoException($"Tài khoản đã tồn tại ");
            }
            var item = _mapper.Map<New, Data.Model.User>(model);
            await _context.Users.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.User, View>(item);
        }

    

        public async Task<int> DeleteAync(int id)
        {
            var item = await _context.Users.Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new Model.CoException($"Cannot find a User: {id} ");
            }
            _context.Users.RemoveRange(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<ViewUserCustomer> GetById(int id)
        {
            var user = await (from a in _context.Users
                              join b in _context.Customers
                              on a.Id equals b.UserId
                              where a.Id == id
                              select new ViewUserCustomer
                              {
                                  Name = a.Name,
                                  Email = a.Email,
                                  PhoneNumbers = a.PhoneNumbers,
                                  FullName = b.FullName,
                                  Address = b.Address,
                                  IdentifierCode = b.IdentifierCode,
                                  ImagePart = b.ImagePart,
                                  Point = b.Point,
                                  Age = b.Age,
                                  Gender = b.Gender,
                                  DateOfBirth = b.DateOfBirth
                              }).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new Model.CoException($"Cannot find a User: {id} ");
            }
            return  _mapper.Map<ViewUserCustomer>(user);
        }

        public async Task<View> GetUser(string email, string password, int phoneNumber)
        {   

            var user = await _context.Users.FirstOrDefaultAsync(x=>x.Email == email || x.PhoneNumbers ==phoneNumber);
            if (user == null)
            {
                throw new Model.CoException($"Cannot find a User ");
            }
            if(user.Password != password)
            {
                throw new Model.CoException($"Sai mật khẩu ");
            }
            return _mapper.Map<Data.Model.User, View>(user);

        }

        public Task<View> GetUserInfo(int CutomerId)
        {
            throw new System.NotImplementedException();
        }
    }
}