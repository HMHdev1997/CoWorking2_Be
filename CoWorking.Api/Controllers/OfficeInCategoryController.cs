using CoWorking.Biz;
using CoWorking.Biz.Model.OfficeInCategory;
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
    public class OfficeInCategoryController : Controller
    {
       
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<OfficeInCategoryController> _logger;

        public OfficeInCategoryController(IRepositoryWapper repository, ILogger<OfficeInCategoryController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Create ([FromForm]New model)
        {
            try
            {
                var item = await _repository.OfficeInCategory.Create(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"create Area Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
