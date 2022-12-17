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
    public class CategoryOfficeController : Controller
    {
        private readonly IRepositoryWapper _repository;
        private readonly ILogger<CategoryOfficeController> _logger;

        public CategoryOfficeController(IRepositoryWapper repository, ILogger<CategoryOfficeController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


    }
}
