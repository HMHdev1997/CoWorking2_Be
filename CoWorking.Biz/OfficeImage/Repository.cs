using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.OfficeImages;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.OfficeImage
{
    public class Repository :IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviromemt;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "Images";


        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment enviromemt, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = enviromemt;
            _storageService = storageService;

    }

        public async Task<View> CreateAsync(New model)
        {
          
            var OfficeImage = new Data.Model.OfficeImage
            {
                OfficeId = model.OfficeId,
                PartImage = await this.SaveFile(model.ImagePart),
                Caption = model.Caption,
                FileSize = model.ImagePart.Length,

            };
            await _context.OfficeImages.AddAsync(OfficeImage);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.OfficeImage, View>(OfficeImage);
        }
      
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<View> GetById(int id)
        {
            var item = await _context.OfficeImages.FirstOrDefaultAsync(x => x.ID == id);
            return _mapper.Map<Data.Model.OfficeImage, Model.OfficeImages.View>(item);
        }
    }
}
