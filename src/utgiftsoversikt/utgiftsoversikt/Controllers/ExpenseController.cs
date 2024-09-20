using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpenseService expenseService, IUserService userService, ILogger<ExpensesController> logger)
        {
            //_expenseService = expenseService;
            _userService = userService;
            _logger = logger;
        }


        [HttpGet("{userId}, {expId}", Name = "GetExpense")]
        public ActionResult<Expense> Get(string id)
        {
            var expense = _expenseService.GetById(id);
            if (expense == null)
                return NotFound();
            return Ok(expense);
        }


        [HttpGet("{userId}", Name = "GetExpenses")]
        public ActionResult<List<Expense>> GetAll(string userId, string month)
        {
            var expenses = _expenseService.GetAllByUserIdAndMonth(userId, month);
            if (expenses == null)
                return NotFound();
            return Ok(expenses);
        }

        [HttpPost("{userId}", Name = "PostExpense")]
        public IActionResult Post(string userId, Expense expense)
        {
            
            _expenseService.Create(userId, expense);
            return Ok(expense.Id);
        }

        [HttpPut("{userId}", Name = "PutExpense")]
        public IActionResult Put(Expense expense)
        {
            _expenseService.Update(expense);
            return Ok();
        }

        [HttpDelete(Name = "DeleteExpense")]
        public IActionResult Delete(Expense expense)
        {

            _expenseService.Delete(expense);
            return Ok();
        }


    }
}
