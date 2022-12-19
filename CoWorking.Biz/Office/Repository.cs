using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model.Offices;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace CoWorking.Biz.Office
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviromemt;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";

        //private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment environment, IStorageService storageService)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = environment;
            _storageService = storageService;
        }

        public async Task<int> AddImage(int OfficeId, Model.OfficeImages.New request)
        {
            var OfficeImage = new Data.Model.OfficeImage()
            {
                Caption = request.Caption,
                OfficeId = OfficeId,
            };
            if (request.ImagePart != null)
            {
                OfficeImage.PartImage = await this.SaveFile(request.ImagePart);
                OfficeImage.FileSize = request.ImagePart.Length;
            }
            await _context.OfficeImages.AddAsync(OfficeImage);
            await _context.SaveChangesAsync();
            return OfficeImage.ID;
        }

        public async Task<View> CreateAync(OfficeCreateRequest request)
        {
            var check =_context.Offices.FirstOrDefault(x => x.NameOffice == request.NameOffice);
            if(check != null)
            {
                return _mapper.Map<Data.Model.Office, Model.Offices.View>(check);
            }
            var newOffice = new Data.Model.Office()
            {
                AreaId = request.AreaId,
                NameOffice = request.NameOffice,
                Address = request.Address,
                GenenalDecription = request.GenenalDecription,
                Detail = request.Detail,
                Tags = request.Tags,
                HotFlag = request.HotFlag,
                ViewCount = request.ViewCount,
                Discount = request.Discount,
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreateDate = request.CreateDate,
                CreateBy = request.CreateBy,
                ModifiedDate = request.ModifiedDate,
                ModifiedBy = request.ModifiedBy,
            };
            if(request.ThumbnailImage != null)
            {
                newOffice.OfficeImages = new List<Data.Model.OfficeImage>()
                {
                    new Data.Model.OfficeImage()
                    {
                          Caption = "Thumbnail Image ",
                          FileSize = request.ThumbnailImage.Length,
                          PartImage = await this.SaveFile(request.ThumbnailImage),
                    }

                };
            }
            await _context.Offices.AddRangeAsync(newOffice);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Office, Model.Offices.View>(newOffice);
         
        }

        public Task<View> GetById(int id)
        {
            throw new NotImplementedException();
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