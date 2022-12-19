using AutoMapper;
using CoWorking.Biz.Model.OfficeImages;
using CoWorking.Data.Access;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.OfficeImage
{
    public class Repository :IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _enviromemt;


        public Repository(DomainDbContext context, IMapper mapper, IWebHostEnvironment enviromemt)
        {
            _context = context;
            _mapper = mapper;
            _enviromemt = enviromemt;

    }

        public async Task<View> CreateAsync(New model)
        {
            string uniqueFileName = ProcessUploadedFile(model);
            var OfficeImage = new Data.Model.OfficeImage
            {
                OfficeId = model.OfficeId,
                PartImage = uniqueFileName,
                Caption = model.Caption,
                FileSize = model.FileSize,

            };
            await _context.OfficeImages.AddAsync(OfficeImage);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.OfficeImage, View>(OfficeImage);
        }
        private string ProcessUploadedFile(New model)
        {
            string uniqueFileName = null;

            if (model.ImagePart != null)
            {
                string uploadsFolder = Path.Combine(_enviromemt.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImagePart.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImagePart.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
