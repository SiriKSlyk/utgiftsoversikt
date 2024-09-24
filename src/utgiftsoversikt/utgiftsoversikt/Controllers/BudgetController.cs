using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;


namespace Utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly IExpenseService _expenseService;
        private readonly IMonthService _monthService;
        private readonly IUserService _userService;

        private readonly ILogger<BudgetController> _logger;

        public BudgetController(IBudgetService budgetService, ILogger<BudgetController> logger)
        {
            _budgetService = budgetService;

            _logger = logger;
        }

        //[HttpGet("{budgetId}", Name = "GetBudget")]
        [HttpGet]
        [Route("/budget/{budgetId}")]
        public ActionResult<Budget> Get(string budgetId)
        {
            var expense = _budgetService.GetById(budgetId);
            if (expense == null)
                return NotFound();
            return Ok(expense);
        }


        //[HttpGet("{userId}, {test}", Name = "GetBudgets")]
        [HttpGet]
        [Route("/budgets/{userId}")]
        public ActionResult<List<Budget>> GetAll(string userId)
        {
            var budgets = _budgetService.GetAll(userId);
            if (budgets == null)
                return NotFound();
            return Ok(budgets);
        }

        //[HttpPost("{userId}", Name = "PostBudget")]
        [HttpPost]
        [Route("/budget/{userId}")]
        public IActionResult Post(string userId, Budget budget)
        {
            budget.UserId = userId;
            _budgetService.Create(budget);
            return Ok(budget.Id);
        }

        //[HttpPut(Name = "PutBudget")]
        [HttpPut]
        [Route("/budget")]
        public IActionResult Put(Budget budget)
        {
            _budgetService.Update(budget);
            return Ok();
        }

        //[HttpDelete(Name = "DeleteBudget")]
        [HttpDelete]
        [Route("/budget")]
        public IActionResult Delete(Budget budget)
        {
            _budgetService.Delete(budget);
            return Ok();
        }

    }
}