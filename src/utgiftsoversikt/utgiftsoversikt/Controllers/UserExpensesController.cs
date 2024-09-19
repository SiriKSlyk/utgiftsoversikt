using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserExpensesController : ControllerBase
    {
        //private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly IUserExpService _userExpService;
        private readonly IMonthlyExpService _monthlyExpService;
        private readonly ILogger<UserExpensesController> _logger;

        public UserExpensesController(IUserExpService userExpService, IUserService userService, IMonthlyExpService monthlyExpService, ILogger<UserExpensesController> logger)
        {
            //_expenseService = expenseService;
            _userExpService = userExpService;
            _userService = userService;
            _monthlyExpService = monthlyExpService;
            _logger = logger;
        }

        [HttpGet("{userId}", Name = "GetUserExpenses")]
        public ActionResult<UserExpenses> Get(string userId)
        {
            var userExp = _userExpService.GetUserExpById(userId);
            return Ok(userExp);
        }



        [HttpPost("{userId}, {budgetId}, {month}", Name = "PostUserExpenses")]
        public ActionResult<Expense> Get(string userId, string budgetId, string month)
        {
            _userExpService.Create(userId, budgetId, month);
            return Ok();
        }


    }
}