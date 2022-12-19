using CoWorking.Biz;
using CoWorking.Biz.Model.Offices;
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
    public class OfficeController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<OfficeController> _logger;

        public OfficeController(IRepositoryWapper repository, ILogger<OfficeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffice ([FromForm] OfficeCreateRequest model)
        {
            try
            {
                var item =await _repository.Office.CreateAync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Office Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
