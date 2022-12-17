using CoWorking.Biz;
using CoWorking.Biz.Model.Area;
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
    public class AreaController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<AreaController> _logger;

        public AreaController(IRepositoryWapper repository, ILogger<AreaController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateAync ([FromForm]New model)
        {
            try
            {
                var item = await _repository.Area.CreateAync(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"create Area Error");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAync([FromForm]Edit model)
        {
            try
            {
                var item = await _repository.Area.UpdateAync(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Update Area Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
