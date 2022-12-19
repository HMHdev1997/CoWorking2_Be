using CoWorking.Biz;
using CoWorking.Biz.Model.CategoryOffice;
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
    public class CategoryOfficeController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<CategoryOfficeController> _logger;

        public CategoryOfficeController(IRepositoryWapper repository, ILogger<CategoryOfficeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAync ([FromForm]New model)
        {
            try
            {
                var item =await _repository.CategoryOffice.CreateAync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Category Office Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update ([FromForm] Edit model)
        {
            try
            {
                var item = await _repository.CategoryOffice.Update(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Update Category Office Error");
                return BadRequest(ex.Message);
            }

        }

    }
}
