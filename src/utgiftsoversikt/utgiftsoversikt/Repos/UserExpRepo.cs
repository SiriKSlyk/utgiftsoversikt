using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Services;

namespace utgiftsoversikt.Repos
{
    public interface IUserExpRepo
    {
        UserExpenses Add(string userId);
        UserExpenses GetUserExpByUserId(string userId);
        void UpdateByUserId(string userId, UserExpenses userExp);
        void Delete(string userId);
        //List<Expense> GetAllExpensesBy(string id);
        /*Expense GetExpenseById(string id);
        bool IdExist(string id);
        void DeleteExpense(Expense expense);
        void UpdateExpense(Expense expense);*/

    }


    public class UserExpRepo : IUserExpRepo
    {

        private readonly CosmosContext _context;

        public UserExpRepo(CosmosContext context)
        {
            _context = context;
        }

        public UserExpenses Add(string userId)
        {
            var userExp = new UserExpenses() { Id = userId, Months = new List<MonthlyExpenses>() { } };
            _context.UserExpenses?.Add(userExp);
            _context.SaveChanges();
            return userExp;
        }

        public void Delete(string userId)
        {
            UserExpenses uEx = GetUserExpByUserId(userId);
            var trackedExpense = _context.ChangeTracker.Entries<UserExpenses>()
            .FirstOrDefault(e => e.Entity.Id == uEx.Id);
            if (trackedExpense != null)
            {
                // Remove trace
                _context.Entry(trackedExpense.Entity).State = EntityState.Detached;
            }

            _context.UserExpenses?.Remove(uEx);
            _context.SaveChangesAsync();
        }

        public UserExpenses GetUserExpByUserId(string userId)
        {
            return _context.UserExpenses?.FirstOrDefault(u=> u.Id == userId);
        }

        public void UpdateByUserId(string userId, UserExpenses userExp)
        {
            _context.UserExpenses?.Update(userExp);
            _context.SaveChangesAsync();
        }

        /*public Expense GetExpenseById(string id)
        {
            return _context.Expenses?.FirstOrDefault(e => e.Id == id);
        }*/

        /*public bool IdExist(string id)
        {
            return _context.Expenses?.FirstOrDefault(e => e.Id == id) != null;
        }*/

        /*public void UpdateExpense(Expense expense)
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
        }*/


    }
}