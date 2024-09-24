using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll(string userId);
        Budget GetById(string id);
<<<<<<< HEAD
        void Create(Budget budget);
        void Update(Budget budget);
        void Delete(Budget budget);
=======
        bool Create(Budget budget);
        bool Update(Budget budget);
        bool Delete(Budget budget);
        void RemoveTrace(Budget budget);
        Task<bool> Write();
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

    }

    public class BudgetRepo : IBudgetRepo
    {

        private readonly CosmosContext _context;

        public BudgetRepo(CosmosContext context)
        {
            _context = context;
        }

        public List<Budget> GetAll(string userId)
        {
            return _context.Budget?.Where(e => e.UserId == userId).ToList();
        }

        public Budget GetById(string id)
        {
            // User id for future authorication: Do this user own this expense
            return _context.Budget?.FirstOrDefault(e => e.Id == id);
        }

<<<<<<< HEAD
        public void Create(Budget budget)
        {
            _context.Budget?.Add(budget);
            _context.SaveChangesAsync();
        }

        public void Update(Budget budget)
        {
            _context.Budget?.Update(budget);
            _context.SaveChangesAsync();
        }
        public void Delete(Budget budget)
        {
            _context?.Budget?.Remove(budget);
            _context.SaveChangesAsync();
=======
        public bool Create(Budget budget)
        {
            _context.Budget?.Add(budget);
            return Write().Result;
        }

        public bool Update(Budget budget)
        {
            _context.Budget?.Update(budget);
            return Write().Result;
        }
        public bool Delete(Budget budget)
        {
            _context?.Budget?.Remove(budget);
            return Write().Result;
        }
        public void RemoveTrace(Budget budget)
        {
            var trackedBudget = _context.ChangeTracker.Entries<Budget>()
            .FirstOrDefault(e => e.Entity.Id == budget.Id);

            if (trackedBudget != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedBudget.Entity).State = EntityState.Detached;
            }
        }
        public async Task<bool> Write()
        {
            return await _context.SaveChangesAsync() > 0;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }

    }
}
