using CoWorking.Biz;
using CoWorking.Biz.Booking;
using CoWorking.Biz.Model.Bookings;
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
    public class BookingController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<BookingController> _logger;

        public BookingController(IRepositoryWapper repository, ILogger<BookingController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> CreeatBooking([FromForm] New model)
        {
            try
            {
                var item = await _repository.Booking.Create(model);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"create Area Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking(int id)
        {
            try
            {
                var item = await _repository.Booking.GetById(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"get Booking {id} Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var item = await _repository.Booking.GetAll();
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"get Booking  Error");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("User")]
        public async Task<IActionResult> GetBookingbyUserId(int id)
        {
            try
            {
                var item = await _repository.Booking.GetBookingbyUserId(id);
                return Ok(item);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex, $"get Booking  Error");
                return BadRequest(ex.Message);
            }
        }
    }
}
