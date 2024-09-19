/*using Microsoft.AspNetCore.Mvc;
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
        //private readonly IExpenseService _expenseService;
        private readonly IUserService _userService;
        private readonly ILogger<ExpensesController> _logger;

        public ExpensesController(IExpenseService expenseService, IUserService userService, ILogger<ExpensesController> logger)
        {
            //_expenseService = expenseService;
            _userService = userService;
            _logger = logger;
        }


        [HttpGet("{userId}, {expId}", Name = "GetExpense")]
        public ActionResult<Expense> Get(string userId, string expId)
        {
            var expense = _expenseService.GetExpenseById(userId, expId);
            if (expense == null)
                return NotFound();
            return Ok(expense);
        }


        [HttpGet("{userId}", Name = "GetAllExpense")]
        public ActionResult<List<Expense>> Get(string userId)
        {
            var expense = _expenseService.GetAllExpensesByUserId(userId);
            if (expense == null)
                return NotFound();
            return Ok(expense);
        }

        [HttpPost("{userId}", Name = "PostExpense")]
        public IActionResult Post(string userId, Expense expense)
        {
            
            _expenseService.CreateExpense(userId, expense);
            return Ok(expense.Id);
        }

        [HttpPut("{userId}", Name = "PutExpense")]
        public IActionResult Put(string userId, Expense expense)
        {

            var result = _expenseService.UpdateExpense(userId, expense);
            return result ? Ok() : BadRequest();
        }

        [HttpDelete("{userId}, {expId}", Name = "DeleteExpense")]
        public IActionResult Delete(string userId, string expId)
        {

            _expenseService.DeleteExpense(userId, expId);
            return Ok();
        }


    }
}
*/