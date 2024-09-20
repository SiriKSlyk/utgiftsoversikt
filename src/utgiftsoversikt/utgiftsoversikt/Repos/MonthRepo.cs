using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IMonthRepo
    {
        List<Month> GetAll(string userId);
        Month GetById(string month);
        List<Month> GetAllInYear(string userId, string year);
        void Create(Month budget);
        void Update(Month budget);
        void Delete(Month budget);

    }

    public class MonthRepo : IMonthRepo
    {

        private readonly CosmosContext _context;

        public MonthRepo(CosmosContext context)
        {
            _context = context;
        }
        public List<Month> GetAll(string userId)
        {
            var result = _context.Month?.Where(m => m.UserId == userId).ToList();
            return result != null ? result : new List<Month>();
        }

        public Month GetById(string month)
        {

            return _context.Month?.FirstOrDefault(m => m.MonthYear == month);
        }

        public List<Month> GetAllInYear(string userId, string year)
        {
            return _context.Month?
                .Where(m => m.UserId == userId && m.MonthYear.Substring(2, m.MonthYear.Length) == year) // Correct user, and check if year is correct by removing month.
                .ToList();
        }

        public void Create(Month month)
        {
            month.Id = Guid.NewGuid().ToString();
            _context.Month?.Add(month);
            _context.SaveChangesAsync();
        }

        public void Update(Month month)
        {
            _context.Month?.Update(month);
            _context.SaveChangesAsync();
        }
        public void Delete(Month month)
        {
            _context.Month?.Remove(month);
            _context.SaveChangesAsync();
        }

    }
}
