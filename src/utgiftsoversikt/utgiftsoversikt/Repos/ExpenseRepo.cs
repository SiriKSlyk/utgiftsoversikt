using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
<<<<<<< HEAD
=======
using utgiftsoversikt.utils;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

namespace utgiftsoversikt.Repos
{
    public interface IExpenseRepo
    {
        List<Expense> GetAll(string userId, string month);
        Expense GetById(string id);
<<<<<<< HEAD
        void Create(Expense expense);
        void Update(Expense expense);
        void Delete(Expense expense);
=======
        bool Create(Expense expense);
        bool Update(Expense expense);
        bool Delete(Expense expense);
        void RemoveTrace(Expense exp);
        Task<bool> Write();
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
    }


    public class ExpenseRepo : IExpenseRepo
    {

        private readonly CosmosContext _context;

        public ExpenseRepo(CosmosContext context)
        {
            _context = context;
        }

        public List<Expense> GetAll(string userId, string month)
        {
<<<<<<< HEAD
            return _context.Expense?.Where(e => e.UserId == userId && e.Month == month).ToList();
=======
            return _context.Expenses.Where(e => e.UserId == userId && e.Month == month).ToList();
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }

        public Expense GetById(string id)
        {
            // User id for future authorication: Do this user own this expense
<<<<<<< HEAD
            return _context.Expense?.FirstOrDefault(e => e.Id == id);
        }

        public void Create(Expense expense)
        {
            _context.Expense?.Add(expense);
            _context.SaveChangesAsync();
        }

        public void Update(Expense expense)
        {
            _context.Expense?.Update(expense);
            _context.SaveChangesAsync();
        }
        public void Delete(Expense expense)
        {
            _context?.Expense?.Remove(expense);
            _context.SaveChangesAsync();
        }
=======
            return _context.Expenses?.FirstOrDefault(e => e.Id == id);
        }

        public bool Create(Expense expense)
        {
            _context.Expenses?.Add(expense);
            return true;

        }

        public bool Update(Expense expense)
        {
            _context.Expenses?.Update(expense);

            return true;
        }
        public bool Delete(Expense expense)
        {

            _context?.Expenses?.Remove(expense);

            return true;
        }

        public void RemoveTrace(Expense exp)
        {
            var trackedExp = _context.ChangeTracker.Entries<Expense>()
            .FirstOrDefault(e => e.Entity.Id == exp.Id);

            if (trackedExp != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedExp.Entity).State = EntityState.Detached;
            }
        }

        public async Task<bool> Write()
        {
            return await _context.SaveChangesAsync() > 0;
        }
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

    }
}
