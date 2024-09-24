using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Models;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonthController : ControllerBase
    {
        private readonly IMonthService _monthService;
        private readonly ILogger<MonthController> _logger;

        public MonthController(IMonthService monthService, ILogger<MonthController> logger)
        {
            _monthService = monthService;
            _logger = logger;
        }

        // Return user with id
        //[HttpGet("{month}", Name = "GetMonth")]
        [HttpGet]
<<<<<<< HEAD
        [Route("/month/{month}")]
        public ActionResult<Month> Get(string month)
        {
            var result = _monthService.Get(month);
=======
        [Route("/month/{userId}/{month}")]
        public ActionResult<Month> Get(string userId, string month)
        {
            var result = _monthService.Get(userId, month);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        // Return user with id
        //[HttpGet(Name = "GetMonths")]
        [HttpGet]
<<<<<<< HEAD
        [Route("/month")]
=======
        [Route("/month/{userId}")]
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        public ActionResult<List<Month>> GetAll(string userId)
        {
            var result = _monthService.GetAll(userId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        // Create a new month
        //[HttpPost(Name = "PostMonth")]
        [HttpPost]
        [Route("/month")]
        public IActionResult Post(Month month)
        {
            _monthService.Create(month);
            return Ok(month.Id);
        }

        //[HttpPut(Name = "PutMonth")]
        [HttpPut]
        [Route("/month")]
        public IActionResult Put(Month month)
        {
            _monthService.Update(month);
            return Ok(month.Id);
        }

        //[HttpDelete(Name = "DeleteMonth")]
        [HttpDelete]
        [Route("/month")]
        public IActionResult Delete(Month month)
        {
            _monthService.Delete(month);
            return Ok(month.Id);
        }
    }
}
