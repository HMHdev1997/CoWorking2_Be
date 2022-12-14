using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.Offices;
using CoWorking.Data.Access;
using CoWorking.Data.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoWorking.Biz.Office
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviromemt;

        //private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = environment;
        
        }

   

        public async Task<View> CreateAync(New model)
        {
            var item = _mapper.Map<New, Data.Model.Office>(model);
            await _context.Offices.AddRangeAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Office, View>(item);
        }
    }
}