using CoWorking.Biz;
using CoWorking.Biz.Model.User;
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
    public class UserController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<UserController> _logger;

        public UserController(IRepositoryWapper repository, ILogger<UserController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> NewUser([FromForm]New  model)
        {
            try
            {
                var item =await _repository.User.CreateAync(model);
                return Ok(item);
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"create user Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromForm]int id)
        {
            try
            {
                await _repository.User.DeleteAync(id);
                return Ok();
            }
            catch(Exception ex)
            {
                _logger.LogInformation(ex, $"Delete User Error");
                return BadRequest(ex.Message);
            }
        }
       
    }
}
