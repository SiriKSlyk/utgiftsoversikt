
using System.Diagnostics.Eventing.Reader;
<<<<<<< HEAD

=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.utils;


namespace utgiftsoversikt.Services
{
    public interface IExpenseService
    {
<<<<<<< HEAD
        void Create(Expense expense);
        List<Expense> GetAllByUserIdAndMonth(string userId, string month);
        Expense GetById(string id);
        public void Delete(Expense expense);
        void Update(Expense expense);
=======
        bool Create(Expense expense);
        List<Expense> GetAllByUserIdAndMonth(string userId, string month);
        Expense GetById(string id);
        bool Delete(Expense expense);
        bool Update(Expense expense);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

    }
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepo _expenseRepo;
        private readonly IMonthRepo _monthRepo;
        private readonly IUserRepo _userRepo;
        

        public ExpenseService(IExpenseRepo expenseRepo, IMonthRepo monthRepo, IUserRepo userRepo)
        {
            _expenseRepo = expenseRepo;
            _monthRepo = monthRepo;
            _userRepo = userRepo;
        }

<<<<<<< HEAD
        public void Create(Expense expense)
        {
=======
        public bool Create(Expense expense)
        {
           
            // add logic to check if expense was created in database
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
            
            _expenseRepo.Create(expense);
        }

<<<<<<< HEAD
        public void Delete(Expense expense)
        {
            _expenseRepo.Delete(expense);
=======
            var month = _monthRepo.GetByUserIdAndMonth(expense.UserId, expense.Month);
            var newMonth = MonthUtils.AddToMonth(expense, month);
            
            var res1 = _expenseRepo.Create(expense);
            var res2 = _monthRepo.Update(newMonth);

            return _expenseRepo.Write().Result && _monthRepo.Write().Result;
        }

        public bool Delete(Expense expense)
        {

            if (expense != null)
                _expenseRepo.RemoveTrace(expense);


            if (_expenseRepo.Delete(expense))
            {
                var month = _monthRepo.GetByUserIdAndMonth(expense.UserId, expense.Month);
                var newMonth = MonthUtils.SubFromMonth(expense, month);
                var result = _monthRepo.Update(newMonth);
                // Change the sum of the month
                return _expenseRepo.Write().Result && _monthRepo.Write().Result;
            }
            return true;

>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }

        public List<Expense> GetAllByUserIdAndMonth(string userId, string month)
        {
            return _expenseRepo.GetAll(userId, month);
        }

        public Expense GetById(string id)
        {
            return _expenseRepo.GetById(id);
        }

<<<<<<< HEAD
        public void Update(Expense expense)
        {
            _expenseRepo.Update(expense);
=======
        public bool Update(Expense expense)
        {
            var exp = GetById(expense.Id);

            _expenseRepo.RemoveTrace(exp);

                

            var monthIdOld = exp.Month;
            var oldMonth = _monthRepo.GetByUserIdAndMonth(exp.UserId, exp.Month);
            exp = expense;
            var newMonth = oldMonth;
            if (monthIdOld != exp.Month)
                newMonth = _monthRepo.GetByUserIdAndMonth(exp.UserId, exp.Month);

            

            var monthUpdate = MonthUtils.EditMonth(exp, expense, oldMonth, newMonth);
            var resExp = _expenseRepo.Update(exp);
            var resMonth = _monthRepo.Update(monthUpdate);


            return _monthRepo.Write().Result && _expenseRepo.Write().Result;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }
    }
}