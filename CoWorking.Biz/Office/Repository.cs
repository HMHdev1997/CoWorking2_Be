using AutoMapper;
using CoWorking.Biz.Common;
using CoWorking.Biz.Model;
using CoWorking.Biz.Model.Offices;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private const string USER_CONTENT_FOLDER_NAME = "Image";

      
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
            var check = _context.Offices.FirstOrDefault(x => x.NameOffice == request.NameOffice);
            if (check != null)
            {
                throw new CoException($"Văn phòng này đã có ");
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
                CreateBy = request.CreateBy,
                ModifiedDate = request.ModifiedDate,
                ModifiedBy = request.ModifiedBy,
            };

            if (request.ThumbnailImage != null)
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

        public async Task<OfficeView> GetById(int id)
        {
            var query =await (from o in _context.Offices
                               join pic in _context.OfficeImages on o.ID equals pic.OfficeId
                               where o.ID == id && pic.OfficeId == id
                               select new OfficeView()
                               {
                                   ID = o.ID,
                                   AreaId = o.AreaId,
                                   NameOffice = o.NameOffice,
                                   GenenalDecription = o.GenenalDecription,
                                   Detail = o.Detail,
                                   Tags = o.Tags,
                                   Discount = o.Discount,
                                   HotFlag = o.HotFlag,
                                   ViewCount = o.ViewCount,
                                   ThumbnailImage = pic.PartImage,
                               }).FirstOrDefaultAsync();
            return _mapper.Map<OfficeView>(query);
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<PageResult<OfficeView>> GetAllPaging(GetPublicProductRequest request)
        {
            var query = (from p in _context.Offices
                         join pic in _context.OfficeImages on p.ID equals pic.OfficeId
                         //join c in _context.OfficeInCategories on p.ID equals c.OfficeId
                         //join a in _context.Areas on p.AreaId equals a.ID
                         //join s in _context.Spaces on p.ID equals s.OfficeId
                         select new { p, pic });
            //paing
            int totalRow = await query.CountAsync();
            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                            .Take(request.PageSize)
                            .Select(x => new OfficeView()
                            {
                                ID = x.p.ID,
                                AreaId = x.p.AreaId,
                                NameOffice = x.p.NameOffice,
                                GenenalDecription = x.p.GenenalDecription,
                                Detail = x.p.Detail,
                                Tags = x.p.Tags,
                                Discount = x.p.Discount,
                                HotFlag = x.p.HotFlag,
                                ViewCount = x.p.ViewCount,
                                ThumbnailImage = x.pic.PartImage,
                            }).ToListAsync();
            var pagedResult = new Model.PageResult<OfficeView>()
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Item = data
            };
            return pagedResult;
        }

        public async Task<int> Delete(int id)
        {
            var item = await _context.Offices.FirstOrDefaultAsync(x => x.ID == id);
            if (item == null)
            {
                throw new CoException($"Cannot find a Office: {id}");
            }
            var images = _context.OfficeImages.Where(x => x.OfficeId == id);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.PartImage);
            }
            _context.Offices.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<View> UpdateOffice(OfficeUpdateRequest request)
        {
            var Office = await _context.Offices.FindAsync(request.ID);

            if (Office == null)
            {
                throw new CoException($"Cannot find a Office: {request}");
            }
            Office.ID = request.ID;
            Office.NameOffice = request.NameOffice;
            Office.AreaId = request.AreaId;
            Office.Address = request.Address;
            Office.GenenalDecription = request.GenenalDecription;
            Office.Detail = request.Detail;
            Office.Tags = request.Tags;
            Office.HotFlag = request.HotFlag;
            Office.ViewCount = request.ViewCount;
            Office.Discount = request.Discount;
            Office.Latitude = request.Latitude;
            Office.Longitude = request.Longitude;
            if (request.ThumbnailImage != null)

            {
                var thumbnailImage = await _context.OfficeImages.FirstOrDefaultAsync(x => x.OfficeId == request.ID);
                if (thumbnailImage != null)
                {
                    thumbnailImage.PartImage = await this.SaveFile(request.ThumbnailImage);
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    _context.OfficeImages.Update(thumbnailImage);
                }
            }
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.Office, View>(Office);
        }

        public async Task<List<Filer>> SearchOffice(string key)
        {
            var item = await _context.Offices.Include(x => x.OfficeImages)
                                             .Include(x=>x.Spaces)
                                             .Where(x => x.NameOffice.Contains(key)).ToListAsync();
            return _mapper.Map<List<Filer>> (item);
        }
    }
}