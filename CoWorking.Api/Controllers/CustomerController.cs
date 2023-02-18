using CoWorking.Biz;
using CoWorking.Biz.Model.Customers;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CoWorking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IRepositoryWapper repository, ILogger<CustomerController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAync([FromForm] New model)
        {
            try
            {
                var user = await _repository.Customer.CreateAync(model);
                return Ok(user);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"create Customer Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(int UserId)
        {
            try
            {
                var customer = await _repository.Customer.GetById(UserId);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Customer Error");
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromForm]Edit model)
        {
            try
            {
                var item = await _repository.Customer.Update( model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Customer Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Point")]
        public async Task<IActionResult> UpdatePoint(int UserId, double Point)
        {
            try
            {
                var item = await _repository.Customer.UpdatePoint(UserId, Point);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Customer Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAync([FromForm]int id)
        {
            try
            {
                await _repository.Customer.DeleteAync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Delete Customer Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Image")]
        public async Task<IActionResult> GetCustomerImage(string path)
        {
            try
            {

                if (path.Contains("/Image/"))
                {
                    path = path.Replace("/Image/", "/Images/");

                }
                if (path.Contains("/User/"))
                {
                    path = path.Replace("/User", "");

                }
                path = @"./wwwroot/" + path;
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