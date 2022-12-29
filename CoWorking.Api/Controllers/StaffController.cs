using CoWorking.Biz;
using CoWorking.Biz.Model.Staff;
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
    public class StaffController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<StaffController> _logger;

        public StaffController(IRepositoryWapper repository, ILogger<StaffController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm]New model)
        {
            try
            {
                var item =await _repository.Staff.CreateAsync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Staff Error");
                return BadRequest(ex.Message);
            }
        }

    }
}
