
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

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public void CreateUser(User user)
        {
            _userRepo.AddUser(user);

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
            _userRepo.UpdateUserByUser(user);
        }

        public void DeleteUser(User user)
        {
            _userRepo.DeleteUser(user);
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