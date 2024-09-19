
using System.Diagnostics.Eventing.Reader;

using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IExpenseService
    {
        void CreateExpense();
        List<Expense> GetAllExpensesByUserId();
        Expense GetExpenseById();
        void DeleteExpense();
        bool IdExist();
        bool UpdateExpense();

    }
    public class ExpenseService : IExpenseService
    {
        private readonly IUserExpRepo _userExpRepo;
        private readonly IUserRepo _userRepo;

        public ExpenseService(IUserExpRepo userExpRepo, IUserRepo userRepo)
        {
            _userExpRepo = userExpRepo;
            _userRepo = userRepo;
        }

        public void CreateExpense(string userId, string month, Expense expense)
        {
            var userExp = _userExpRepo.GetUserExpByUserId(userId);
            userExp.Months.FirstOrDefault(m => m.Month == month);
        }

        public void DeleteExpense()
        {
            
        }

        public List<Expense> GetAllExpensesByUserId()
        {
            

        }

        public Expense GetExpenseById()
        {
           
        }

        public bool IdExist()
        {
            
        }

        public bool UpdateExpense()
        {

        }
    }
}