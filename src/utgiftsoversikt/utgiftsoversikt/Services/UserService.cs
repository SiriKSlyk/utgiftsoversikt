
using System.Diagnostics.Eventing.Reader;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> FindAllUsers();
        User GetUserById(string id);
        User GetUserByEmail(string email);
        void UpdateUser(User user);
        void DeleteUser(User user);
        bool IdExist(string id);
        bool EmailExist(string email);

    }
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;
        private readonly IUserExpRepo _userExpRepo;

        public UserService(IUserRepo userRepo, IUserExpRepo userExpRepo)
        {
            _userRepo = userRepo;
            _userExpRepo = userExpRepo;
        }

        public void CreateUser(User user)
        {
            user = new User() { First_name = user.First_name, Last_name = user.Last_name, Email = user.Email, Is_admin = false };
            _userRepo.AddUser(user);
            _userExpRepo.Add(user.Id); // Creating an empty Overview over all expenses for this user

        }

        public List<User> FindAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User GetUserById(string id)
        {
            return _userRepo.GetUserById(id);
        }

        public User GetUserByEmail(string email)
        {
            return _userRepo.GetUserByEmail(email);
        }

        public void UpdateUser(User user)
        {
            var oldUser = _userRepo.GetUserById(user.Id);

            // Forcing values not to change
            user.Id = oldUser.Id;
            user.Is_admin = oldUser.Is_admin;
            user.BudgetId = oldUser.BudgetId;

            _userRepo.UpdateUserByUser(user);
        }

        public void DeleteUser(User user)
        {
            _userRepo.DeleteUser(user);
            _userExpRepo.Delete(user.Id);
        }
        public bool UserExist(User user)
        {
            return _userRepo.IdExist(user.Id) && _userRepo.EmailExist(user.Email);
        }
        public bool IdExist(string id)
        {
            return _userRepo.IdExist(id);
        }
        public bool EmailExist(string email)
        {

            return _userRepo.EmailExist(email);

        }
    }
}