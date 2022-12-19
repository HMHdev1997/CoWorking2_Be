using CoWorking.Biz;
using CoWorking.Biz.Model.CategoryService;
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
    public class CategoryServiceController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<CategoryServiceController> _logger;

        public CategoryServiceController(IRepositoryWapper repository, ILogger<CategoryServiceController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAync ([FromForm] New model)
        {
            try
            {
                var item = await _repository.CategoryService.CreateAync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Category Service Error");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] Edit model)
        {
            try
            {
                var item = await _repository.CategoryService.Update(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"update Category Service Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
