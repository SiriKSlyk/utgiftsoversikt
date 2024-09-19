using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;

namespace utgiftsoversikt.Services
{
    public interface IUserExpService
    {
        void Create(string userId, string budgetId, string month);
        UserExpenses GetUserExpById(string userId);


    }
    public class UserExpService : IUserExpService
    {
        private readonly IUserRepo _userRepo;
        private readonly IUserExpRepo _userExpRepo;
        private readonly IMonthlyExpService _monthlyExpService;

        public UserExpService(IUserRepo userRepo, IUserExpRepo userExpRepo, IMonthlyExpService monthlyExpService)
        {
            _userRepo = userRepo;
            _userExpRepo = userExpRepo;
            _monthlyExpService = monthlyExpService;
        }

        public void Create(string userId, string budgetId, string month)
        {
            //Check if allready exisiting 

            // Check if month-value is valid
            //

            var userExp = _userExpRepo.Add(userId);
            budgetId = Guid.NewGuid().ToString(); // Until budget is created in project
            _monthlyExpService.CreateWithUserExp(userExp, budgetId, month);
        }
        
        public UserExpenses GetUserExpById(string userId)
        {
            return _userExpRepo.GetUserExpByUserId(userId);
        }

    }
}

