using CoWorking.Biz;
using CoWorking.Biz.Model.Role;
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
    public class RoleController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<RoleController> _logger;

        public RoleController (IRepositoryWapper repository, ILogger<RoleController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync ([FromForm]New model)
        {
            try
            {
                var item = await _repository.Role.CreateAsync(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Create role Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
