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
        private readonly IStorageService _storageService;


        public RepositoryWapper(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = environment;
            _storageService = storageService;

        }

        private Customer.IRepository _customer;
        public IRepository Customer => _customer ??= new Customer.Repository(_context, _mapper, _enviromemt, _storageService);

        private CategoryOffice.IRepository _categoryOffice;
        public CategoryOffice.IRepository CategoryOffice => _categoryOffice ??= new CategoryOffice.Repository(_context, _mapper);

        private CategoryService.IRepository _categoryService;
        public CategoryService.IRepository CategoryService => _categoryService ??= new CategoryService.Repository(_context, _mapper);

        private Area.IRepository _area;
        public Area.IRepository Area => _area ??= new Area.Repository(_context, _mapper);

        private CategorySpace.IRepository _categorySpace;
        public CategorySpace.IRepository CategorySpace => _categorySpace ??= new CategorySpace.Repository(_context, _mapper);

        private Office.IRepository _office;
        public Office.IRepository Office => _office ??= new Office.Repository(_context, _mapper, _enviromemt, _storageService);

        private User.IRepository _user;
        public User.IRepository User => _user ??= new User.Repository(_context, _mapper);

        private OfficeImage.IRepository _officeImage;
        public OfficeImage.IRepository OfficeImage => _officeImage ??= new OfficeImage.Repository(_context, _mapper, _enviromemt, _storageService);

        private Booking.IRepository _booking;
        public Booking.IRepository Booking => _booking ??= new Booking.Repository(_context, _mapper);
        private BookingDetail.IRepository _bookingDetail;
        public BookingDetail.IRepository BookingDetail => _bookingDetail ??= new BookingDetail.Repository(_context, _mapper);
        private OfficeInCategory.IRepository _officeInCategory;
        public OfficeInCategory.IRepository OfficeInCategory => _officeInCategory ??= new OfficeInCategory.Repository(_context, _mapper);

        private Role.IRepository _role;
        public Role.IRepository Role => _role ??= new Role.Repository(_context, _mapper);

        private FeedBack.IRepository _feedBack;
        public FeedBack.IRepository FeedBack => _feedBack ??= new FeedBack.Repository(_context, _mapper);

        private Staff.IRepository _staff;
        public Staff.IRepository Staff => _staff ??= new Staff.Repository(_context, _mapper);
    }
}
