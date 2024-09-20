using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IBudgetRepo
    {
        List<Budget> GetAll(string userId);
        Budget GetById(string id);
        void Create(Budget budget);
        void Update(Budget budget);
        void Delete(Budget budget);

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
        }

    }
}
