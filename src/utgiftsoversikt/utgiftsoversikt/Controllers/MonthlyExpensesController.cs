using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MonthlyExpensesController : ControllerBase
    {
        //private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly IUserExpService _userExpService;
        private readonly IMonthlyExpService _monthlyExpService;

        private readonly ILogger<MonthlyExpensesController> _logger;

        public MonthlyExpensesController(IUserExpService userExpService, IUserService userService, IMonthlyExpService monthlyExpService, ILogger<MonthlyExpensesController> logger)
        {
            //_expenseService = expenseService;
            _userService = userService;
            _userExpService = userExpService;
            _monthlyExpService = monthlyExpService;
            _logger = logger;
        }

        [HttpGet("{userId}, {month}", Name = "GetMonthlyExpenses")]
        public ActionResult<MonthlyExpenses> Get(string userId, string month)
        {
            var userExp = _monthlyExpService.GetMonthlyExpensesByIdAndMonth(userId, month);
            return Ok(userExp);
        }

        [HttpGet("{userId}", Name = "GeAlltMonthlyExpenses")]
        public ActionResult<List<MonthlyExpenses>> Get(string userId)
        {
            var userExp = _monthlyExpService.GetAllMonthlyExpensesById(userId);
            if (userExp == null)
                return BadRequest();
            return Ok(userExp);
        }



        [HttpPost("{userId}, {budgetId}, {month}", Name = "PostMonthlyExpenses")]
        public ActionResult Post(string userId, string budgetId, string month)
        {
            _monthlyExpService.CreateWithUserId(userId, budgetId, month);
            return Ok();
        }


    }
}