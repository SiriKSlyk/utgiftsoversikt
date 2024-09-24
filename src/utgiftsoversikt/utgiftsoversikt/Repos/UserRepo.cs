﻿using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;

namespace utgiftsoversikt.Repos
{
    public interface IUserRepo
    {
        bool AddUser(User user);
        List<User> GetAllUsers();
        User GetUserById(string id);
        bool IdExist(string id);
        bool EmailExist(string email);
        bool DeleteUser(User user);
        bool UpdateUserByUser(User newUser);
        User GetUserByEmail(string email);
        void RemoveTrace(User user);
        Task<bool> Write();

    }
    
    
    public class UserRepo: IUserRepo
    {

        private readonly CosmosContext _context;

        public UserRepo(CosmosContext context)
        {
            _context = context;
        }

        // Creates and give user a new uniqe id
        public bool AddUser(User user)
        {
            
            _context.Users.Add(user);
<<<<<<< HEAD
            _context.SaveChangesAsync();
=======
            return Write().Result;
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa
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

        public bool UpdateUserByUser(User user)
        {

<<<<<<< HEAD
            var trackedUser = _context.ChangeTracker.Entries<User>()
            .FirstOrDefault(e => e.Entity.Id == user.Id);
            if (trackedUser != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedUser.Entity).State = EntityState.Detached;
            }
=======
            RemoveTrace(user);
>>>>>>> 6adc23507ea9aeabd4e85b10a1e9c111d6d5a6fa

            _context.Users?.Update(user);
            return Write().Result;

        }

        public bool DeleteUser(User user)
        {
            RemoveTrace(user);

            _context.Users?.Remove(user);
            return Write().Result;
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
        public void RemoveTrace(User user)
        {
            var trackedUser = _context.ChangeTracker.Entries<User>()
            .FirstOrDefault(e => e.Entity.Id == user.Id);
            
            if (trackedUser != null)
            {
                // Fjern den eksisterende sporing
                _context.Entry(trackedUser.Entity).State = EntityState.Detached;
            }
        }
        public async Task<bool> Write()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
