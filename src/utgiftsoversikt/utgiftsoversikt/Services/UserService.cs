
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;


namespace utgiftsoversikt.Services
{
    public interface IUserService
    {
        void CreateUser(User user);
        List<User> FindAllUsers();
        User FindUserById(string id);
        User FindUserByName(string name);
        public void UpdateUser(User newUser);
        void DeleteUser(User user);
        bool IdExist(string id);

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

        public User FindUserById(string id)
        {
            return _userRepo.GetUserById(id);
        }

        public User FindUserByName(string name)
        {
            return _userRepo.GetUserByName(name);
        }

        public void UpdateUser(User newUser)
        {
            _userRepo.UpdateUserByUser(newUser);
        }

        public void DeleteUser(User user)
        {
            _userRepo.DeleteUser(user);
        }
        public bool UserExist(User user)
        {
            return _userRepo.IdExist(user.Id) && _userRepo.NameExist(user.Name);
        }
        public bool IdExist(string id)
        {
            return _userRepo.IdExist(id);
        }
    }
}