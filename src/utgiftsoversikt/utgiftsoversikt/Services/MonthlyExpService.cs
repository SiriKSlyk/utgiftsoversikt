using System.Diagnostics.Eventing.Reader;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;

namespace utgiftsoversikt.Services
{

    public interface IMonthlyExpService
    {
        void CreateWithUserId(string userId, string budgetId, string month);
        void CreateWithUserExp(UserExpenses userExp, string budgetId, string month);
        List<MonthlyExpenses> GetAllMonthlyExpensesById(string userId);
        MonthlyExpenses GetMonthlyExpensesByIdAndMonth(string userId, string month);


    }


    public class MonthlyExpService: IMonthlyExpService
    {
        
        private readonly IUserRepo _userRepo;
        private readonly IUserExpRepo _userExpRepo;

        public MonthlyExpService(IUserRepo userRepo, IUserExpRepo userExpRepo)
        {
            _userRepo = userRepo;
            _userExpRepo = userExpRepo;
        }

        public void CreateWithUserId(string userId, string budgetId, string month)
        {
            var userExp = _userExpRepo.GetUserExpByUserId(userId);
            CreateWithUserExp(userExp, budgetId, month);
        }

        public void CreateWithUserExp(UserExpenses userExp, string budgetId, string month)
        {
            var monthly = new MonthlyExpenses() { Month = month, BudgetId = budgetId };
            if (userExp.Months != null)
            {
                userExp.Months.Add(monthly);
            }
            else
            {
                userExp.Months = new List<MonthlyExpenses>() { monthly };
            }
            _userExpRepo.UpdateByUserId(monthly.Id, userExp);
        }

        public List<MonthlyExpenses> GetAllMonthlyExpensesById(string userId)
        {
            var userExp = _userExpRepo.GetUserExpByUserId(userId);
            return userExp.Months;
        }

        public MonthlyExpenses GetMonthlyExpensesByIdAndMonth(string userId, string month)
        {
            var userExp = _userExpRepo.GetUserExpByUserId(userId);
            return userExp.Months.FirstOrDefault(m => m.Month == month);

        }

        public void UpdateMonthlyExpByUserId(string userId, UserExpenses userExp)
        {
            _userExpRepo.UpdateByUserId(userId, userExp);
        }


    }
}
