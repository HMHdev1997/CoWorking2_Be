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
    }
}
