using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Customer;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz
{
    public class RepositoryWapper : IRepositoryWapper
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviromemt;
      



        public RepositoryWapper(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;         
            _enviromemt = environment;

        }

        private Customer.IRepository _customer;
        public IRepository Customer => _customer ??= new Customer.Repository(_context, _mapper, _enviromemt);

        private CategoryOffice.IRepository _categoryOffice;
        public CategoryOffice.IRepository CategoryOffice => _categoryOffice ??= new CategoryOffice.Repository(_context, _mapper);

        private CategoryService.IRepository _categoryService;
        public CategoryService.IRepository CategoryService => _categoryService ??= new CategoryService.Repository(_context, _mapper);

        private Area.IRepository _area;
        public Area.IRepository Area => _area ??= new Area.Repository(_context, _mapper);

        private CategorySpace.IRepository _categorySpace;
        public CategorySpace.IRepository CategorySpace => _categorySpace ??= new CategorySpace.Repository(_context, _mapper) ;

        private Office.IRepository _office;
        public Office.IRepository Office => _office ??= new Office.Repository(_context, _mapper, _enviromemt);

        private User.IRepository _user;
        public User.IRepository User => _user ??= new User.Repository(_context, _mapper);
    }
}
