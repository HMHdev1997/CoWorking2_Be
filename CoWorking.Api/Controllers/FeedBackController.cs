using CoWorking.Biz;
using CoWorking.Biz.Model.FeedBack;
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
    public class FeedBackController : Controller
    {

        private readonly IRepositoryWapper _repository;
        private readonly ILogger<FeedBackController> _logger;

        public FeedBackController(IRepositoryWapper repository, ILogger<FeedBackController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync ([FromForm]New model)
        {
            try
            {
                var item =await _repository.FeedBack.CreateAsync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Create Feedback Error");
                return BadRequest(ex.Message);
            }          
        }
        [HttpPut]
        public async Task<IActionResult> Update ([FromForm]Edit model)  
        {
            try
            {
                var item = await _repository.FeedBack.Update(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Create Feedback Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete ([FromForm] int id)
        {
            try
            {
                 await _repository.FeedBack.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Create Feedback Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
