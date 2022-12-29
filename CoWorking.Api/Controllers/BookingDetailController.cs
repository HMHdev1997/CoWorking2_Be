using CoWorking.Biz;
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
    public class BookingDetailController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<BookingDetailController> _logger;

        public BookingDetailController(IRepositoryWapper repository, ILogger<BookingDetailController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
    }
}
