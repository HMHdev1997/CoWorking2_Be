using CoWorking.Biz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoWorking.Biz.Model.BookingDetail;
namespace CoWorking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingDetailController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<BookingDetailController> _logger;

        public BookingDetailController(IRepositoryWapper repository, ILogger<BookingDetailController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreeatBookingDetail([FromForm] New model)
        {
            try
            {
                var item = await _repository.BookingDetail.Create(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"create Area Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var item = await _repository.BookingDetail.GetAll();
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"get Booking  Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking(int id)
        {
            try
            {
                var item = await _repository.BookingDetail.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"get Booking {id} Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
