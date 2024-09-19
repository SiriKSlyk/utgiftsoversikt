
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata.Ecma335;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IExpenseService
    {
        void CreateExpense(string userId, Expense expense);
        List<Expense> GetAllExpensesByUserId(string id);
        Expense GetExpenseById(string userId, string expId);
        void DeleteExpense(string userId, string expId);
        bool IdExist(string userId, string expId);
        bool UpdateExpense(string userId, Expense expense);

    }
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepo _expenseRepo;
        private readonly IUserRepo _userRepo;

        public ExpenseService(IExpenseRepo expenseRepo, IUserRepo userRepo)
        {
            _expenseRepo = expenseRepo;
            _userRepo = userRepo;
        }

        public void CreateExpense(string userId, Expense expense)
        {
            expense.Id = Guid.NewGuid().ToString();
            var user = _userRepo.GetUserById(userId);
            user.Expenses.Add(expense);
            _userRepo.UpdateUserByUser(user);
        }

        public void DeleteExpense(string userId, string expId)
        {
            var user = _userRepo.GetUserById(userId);
            var expense = user.Expenses.FirstOrDefault(e => e.Id == expId);
            user.Expenses.Remove(expense);
            _userRepo.UpdateUserByUser(user);
        }

        public List<Expense> GetAllExpensesByUserId(string id)
        {
            var user = _userRepo.GetUserById(id);
            return user.Expenses;

        }

        public Expense GetExpenseById(string userId, string expId)
        {
            var user = _userRepo.GetUserById(userId);
            return user.Expenses.FirstOrDefault(e => e.Id == expId);
        }

        public bool IdExist(string userId, string expId)
        {
            return GetExpenseById(userId, expId) != null;
        }

        public bool UpdateExpense(string userId, Expense expense)
        {
            if (IdExist(userId, expense.Id) || true)
            {
                var user = _userRepo.GetUserById(userId);
                var oldExpense = user.Expenses.FirstOrDefault(e => e.Id == expense.Id);
                user.Expenses.Remove(oldExpense);
                user.Expenses.Add(expense);
                _userRepo.UpdateUserByUser(user);
                return true;
            }
            return false;
               
            

        }
    }
}