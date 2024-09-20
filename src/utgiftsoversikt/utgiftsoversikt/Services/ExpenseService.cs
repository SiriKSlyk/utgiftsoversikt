
using System.Diagnostics.Eventing.Reader;

using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IExpenseService
    {
        void Create(Expense expense);
        List<Expense> GetAllByUserIdAndMonth(string userId, string month);
        Expense GetById(string id);
        public void Delete(Expense expense);
        void Update(Expense expense);

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

        public void Create(Expense expense)
        {
            
            _expenseRepo.Create(expense);
        }

        public void Delete(Expense expense)
        {
            _expenseRepo.Delete(expense);
        }

        public List<Expense> GetAllByUserIdAndMonth(string userId, string month)
        {
            return _expenseRepo.GetAll(userId, month);
        }

        public Expense GetById(string id)
        {
            return _expenseRepo.GetById(id);
        }

        public void Update(Expense expense)
        {
            _expenseRepo.Update(expense);
        }
    }
}