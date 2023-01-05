using CoWorking.Biz;
using CoWorking.Biz.Model.OfficeImages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoWorking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficeImageController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<OfficeImageController> _logger;

        public OfficeImageController(IRepositoryWapper repository, ILogger<OfficeImageController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateImage ([FromForm]New model)
        {
            try
            {
                var item = await _repository.OfficeImage.CreateAsync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Office Image ");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var item = await _repository.OfficeImage.GetById(id);
                string path = @"./wwwroot/" + item.PartImage;

                if (path.Contains("/Image/"))
                {
                    path = path.Replace("/Image/", "/Images/");

                }
                Byte[] b = System.IO.File.ReadAllBytes(path);
                return Ok(File(b, "image/jpeg"));
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Office Image ");
                return BadRequest(ex.Message);
            }
        }

    }
}
