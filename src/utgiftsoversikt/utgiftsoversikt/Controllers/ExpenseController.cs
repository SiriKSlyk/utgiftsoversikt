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


        //[HttpGet("{expId}", Name = "GetExpense")]
        [HttpGet]
        [Route("/expense/{expId}")]
        public ActionResult<Expense> Get(string expId)
        {
            var expense = _expenseService.GetById(expId);
            if (expense == null)
                return NotFound();
            return Ok(expense);
        }


        //[HttpGet("{userId}", Name = "GetExpenses")]
        [HttpGet]
        [Route("/expenses")]
        public ActionResult<List<Expense>> GetAll(string userId, string month)
        {
            var expenses = _expenseService.GetAllByUserIdAndMonth(userId, month);
            if (expenses == null)
                return NotFound();
            return Ok(expenses);
        }

        //[HttpPost("{userId}", Name = "PostExpense")]
        [HttpPost]
        [Route("/expense")]
        public IActionResult Post(string userId, Expense expense)
        {
            expense.UserId = userId;
            _expenseService.Create(expense);
            return Ok(expense.Id);
        }

        //[HttpPut(Name = "PutExpense")]
        [HttpPut]
        [Route("/expense")]
        public IActionResult Put(Expense expense)
        {
            _expenseService.Update(expense);
            return Ok();
        }

        //[HttpDelete(Name = "DeleteExpense")]
        [HttpDelete]
        [Route("/expense")]
        public IActionResult Delete(Expense expense)
        { 
            _expenseService.Delete(expense);
            return Ok();
        }


    }
}
