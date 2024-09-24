using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IMonthService
    {
<<<<<<< HEAD
        void Create(Month month);
        Month Get(string month);
        List<Month> GetAll(string userId);
        List<Month> GetAllInYear(string userId, string year);
        void Update(Month month);
        void Delete(Month month);
=======
        bool Create(Month month);
        Month Get(string userId, string month);
        List<Month> GetAll(string userId);
        List<Month> GetAllInYear(string userId, string year);
        bool Update(Month month);
        bool Delete(Month month);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

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

<<<<<<< HEAD
        public void Create(Month month)
        {
            _monthRepo.Create(month);
        }
        public Month Get(string month)
        {
            return _monthRepo.GetById(month);
=======
        public bool Create(Month month)
        {
            _monthRepo.Create(month);
            return _monthRepo.Write().Result;
        }
        public Month Get(string userId, string month)
        {
            return _monthRepo.GetByUserIdAndMonth(userId, month);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
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
<<<<<<< HEAD
        public void Update(Month month)
        {
            _monthRepo.Update(month);
        }
        public void Delete(Month month)
        {
            _monthRepo.Delete(month);
=======
        public bool Update(Month month)
        {
            _monthRepo.RemoveTrace(month);
            _monthRepo.Update(month);
            return _monthRepo.Write().Result;
        }
        public bool Delete(Month month)
        {
            _monthRepo.RemoveTrace(month);
            _monthRepo.Delete(month);
            return _monthRepo.Write().Result;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
        }
    }
}