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
        [HttpGet("paging")]
        public async Task<IActionResult> GetPageOffice([FromQuery] GetPublicProductRequest model)
        {
            try
            {
                var item = await _repository.Office.GetAllPaging(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Office Error");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetbyId([FromQuery] int id)
        {
            try
            {
                var item = await _repository.Office.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Office Error: {id}");
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string key)
        {
            try
            {
                var item = await _repository.Office.SearchOffice(key);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Get Office Error: {key}");
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete ([FromForm]int id)
        {
            try
            {
                await _repository.Office.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Delete Office Error");
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromForm] OfficeUpdateRequest model)
        {
            try
            {
                var item = await _repository.Office.UpdateOffice(model);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"Update Office Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
