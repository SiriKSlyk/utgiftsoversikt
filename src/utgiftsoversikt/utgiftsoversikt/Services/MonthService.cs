using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IMonthService
    {
        void Create(Month month);
        Month Get(string month);
        List<Month> GetAll(string userId);
        List<Month> GetAllInYear(string userId, string year);
        void Update(Month month);
        void Delete(Month month);

    }
    public class MonthService : IMonthService
    {
        private readonly IUserRepo _userRepo;
        private readonly IMonthRepo _monthRepo;

        public MonthService(IMonthRepo monthRepo, IUserRepo userRepo)
        {
            _monthRepo = monthRepo;
            _userRepo = userRepo;
        }

        public void Create(Month month)
        {
            _monthRepo.Create(month);
        }
        public Month Get(string month)
        {
            return _monthRepo.GetById(month);
        }
        public List<Month> GetAll(string userId)
        {
            return _monthRepo.GetAll(userId);
        }
        public List<Month> GetAllInYear(string userId, string year)
        {
            int yearInt = int.Parse(year);
            if (1950 <= yearInt && yearInt <= 2024) {
                return _monthRepo.GetAllInYear(userId, year);
            }
            return new List<Month>();

        }
        public void Update(Month month)
        {
            _monthRepo.Update(month);
        }
        public void Delete(Month month)
        {
            _monthRepo.Delete(month);
        }
    }
}