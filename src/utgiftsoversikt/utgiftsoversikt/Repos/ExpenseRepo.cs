using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Repos
{
    public interface IExpenseRepo
    {
        void AddExpense(Expense expense);
        //List<Expense> GetAllExpensesBy(string id);
        Expense GetExpenseById(string id);
        bool IdExist(string id);
        void DeleteExpense(Expense expense);
        void UpdateExpense(Expense expense);

    }


    public class ExpenseRepo : IExpenseRepo
    {

        private readonly CosmosContext _context;

        public ExpenseRepo(CosmosContext context)
        {
            _context = context;
        }

        public void AddExpense(Expense expense)
        {

            var newExpense = new Expense()
            {
                
                Date = expense.Date,
                Shop = expense.Shop,
                Category = expense.Category,
                Sum = expense.Sum,
                Description = expense.Description //.Trim() == "" ? "No description" : expense.Description

            };
            _context.Expenses?.Add(newExpense);
            _context.SaveChanges();
        }

        public void DeleteExpense(Expense expense)
        {
            var trackedExpense = _context.ChangeTracker.Entries<Expense>()
            .FirstOrDefault(e => e.Entity.Id == expense.Id);
            if (trackedExpense != null)
            {
                // Remove trace
                _context.Entry(trackedExpense.Entity).State = EntityState.Detached;
            }

            _context.Expenses?.Remove(expense);
            _context.SaveChangesAsync();
        }

        /*public List<Expense> GetAllExpenses(string gid)
        {
            return _context.Expenses?.ToList();
        }*/

        public Expense GetExpenseById(string id)
        {
            return _context.Expenses?.FirstOrDefault(e => e.Id == id);
        }

        public bool IdExist(string id)
        {
            return _context.Expenses?.FirstOrDefault(e => e.Id == id) != null;
        }

        public void UpdateExpense(Expense expense)
        {

            var trackedUser = _context.ChangeTracker.Entries<Expense>()
            .FirstOrDefault(e => e.Entity.Id == expense.Id);
            if (trackedUser != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedUser.Entity).State = EntityState.Detached;
            }

            _context.Expenses?.Update(expense);
            _context.SaveChangesAsync();
        }


    }
}