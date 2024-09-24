using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IMonthRepo
    {
        List<Month> GetAll(string userId);
<<<<<<< HEAD
        Month GetById(string month);
        List<Month> GetAllInYear(string userId, string year);
        void Create(Month budget);
        void Update(Month budget);
        void Delete(Month budget);
=======
        Month GetByUserIdAndMonth(string userId, string month);
        List<Month> GetAllInYear(string userId, string year);
        bool Create(Month budget);
        bool Update(Month budget);
        bool Delete(Month budget);
        void RemoveTrace(Month month);

        Task<bool> Write();
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

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

<<<<<<< HEAD
        public Month GetById(string month)
        {

            return _context.Month?.FirstOrDefault(m => m.MonthYear == month);
=======
        public Month GetByUserIdAndMonth(string userId, string month)
        {

            return _context.Month?.FirstOrDefault(m => m.UserId == userId && m.MonthYear == month);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }

        public List<Month> GetAllInYear(string userId, string year)
        {
            return _context.Month?
                .Where(m => m.UserId == userId && m.MonthYear.Substring(2, m.MonthYear.Length) == year) // Correct user, and check if year is correct by removing month.
                .ToList();
        }

<<<<<<< HEAD
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

=======
        public bool Create(Month month)
        {
            month.Id = Guid.NewGuid().ToString();
            _context.Month?.Add(month);
            return true;
        }

        public bool Update(Month month)
        {

            _context.Month?.Update(month);
            return true;
        }
        public bool Delete(Month month)
        {

            _context.Month?.Remove(month);
            return true;
        }

        public void RemoveTrace(Month month)
        {
            var trackedMonth = _context.ChangeTracker.Entries<Month>()
            .FirstOrDefault(e => e.Entity.Id == month.Id);

            if (trackedMonth != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedMonth.Entity).State = EntityState.Detached;
            }
        }
        public async Task<bool> Write()
        {
            return await _context.SaveChangesAsync() > 0;
        }
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
    }
}
