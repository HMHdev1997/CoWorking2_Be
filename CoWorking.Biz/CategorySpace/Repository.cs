using AutoMapper;
using CoWorking.Data.Access;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.CategorySpace
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

    }
}
