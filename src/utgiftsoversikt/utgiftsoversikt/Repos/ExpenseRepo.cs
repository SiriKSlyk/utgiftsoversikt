using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IExpenseRepo
    {
        List<Expense> GetAll(string userId, string month);
        Expense GetById(string id);
        void Create(Expense expense);
        void Update(Expense expense);
        void Delete(Expense expense);
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
            return _context.Expense?.Where(e => e.UserId == userId && e.Month == month).ToList();
        }

        public Expense GetById(string id)
        {
            // User id for future authorication: Do this user own this expense
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

    }
}
