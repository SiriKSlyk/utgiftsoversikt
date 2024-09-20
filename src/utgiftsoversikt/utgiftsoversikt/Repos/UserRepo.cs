using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IUserRepo
    {
        void AddUser(User user);
        List<User> GetAllUsers();
        User GetUserById(string id);
        bool IdExist(string id);
        bool EmailExist(string email);
        void DeleteUser(User user);
        void UpdateUserByUser(User newUser);
        User GetUserByEmail(string email);

    }
    
    
    public class UserRepo: IUserRepo
    {

        private readonly CosmosContext _context;

        public UserRepo(CosmosContext context)
        {
            _context = context;
        }

        // Creates and give user a new uniqe id
        public void AddUser(User user)
        {
            
            _context.Users.Add(user);
            _context.SaveChangesAsync();
        }

        public List<User> GetAllUsers()
        {

            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(string id)
        {
            var user = _context.Users?.FirstOrDefault(u => u.Id == id);

            return user;

        }

        // Endres senere til et unikt felt
        public User GetUserByEmail(string name)
        {
            var user = _context.Users?.FirstOrDefault(u => u.Email.ToLower() == name.ToLower());

            return user;
        }

        public void UpdateUserByUser(User user)
        {

            var trackedUser = _context.ChangeTracker.Entries<User>()
            .FirstOrDefault(e => e.Entity.Id == user.Id);
            if (trackedUser != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedUser.Entity).State = EntityState.Detached;
            }

            _context.Users?.Update(user);
            _context.SaveChangesAsync();

        }

        public void DeleteUser(User user)
        {
            var trackedUser = _context.ChangeTracker.Entries<User>()
            .FirstOrDefault(e => e.Entity.Id == user.Id);
            if (trackedUser != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedUser.Entity).State = EntityState.Detached;
            }

            _context.Users?.Remove(user);
            _context.SaveChangesAsync();
        }

        public bool EmailExist(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());

            return user != null;

        }

        public bool IdExist(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            return user != null;

        }
    }
}
