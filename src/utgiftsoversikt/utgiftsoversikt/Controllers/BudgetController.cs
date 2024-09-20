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

        public BudgetController(IBudgetService budgetService, IExpenseService expenseService, IMonthService monthService, IUserService userService, ILogger<BudgetController> logger)
        {
            _budgetService = budgetService;
            _expenseService = expenseService;
            _monthService = monthService;
            _userService = userService;

            _logger = logger;
        }

        

    }
}