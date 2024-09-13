using utgiftsoversikt.Models;

namespace Utgiftsoversikt.Service
{
    public class UserService
    {
        // Mock av fremtidig database
        private static List<User> Users = new List<User>
            {
                new User { Id = 1, Name = "Alice", Age = 30 },
                new User { Id = 2, Name = "Bob", Age = 25 },
                new User { Id = 3, Name = "Charlie", Age = 35 },
                new User { Id = 4, Name = "David", Age = 28 },
                new User { Id = 5, Name = "Eve", Age = 32 },
                new User { Id = 6, Name = "Frank", Age = 40 },
                new User { Id = 7, Name = "Grace", Age = 29 },
                new User { Id = 8, Name = "Hannah", Age = 24 },
                new User { Id = 9, Name = "Isaac", Age = 31 },
                new User { Id = 10, Name = "Jack", Age = 27 },
            };

        public static List<User> FindAllUsers()
        {
            return Users;
        }

        // Henter User om den eksisterer eller returnerer null
        public static User? FindUserById(int id)
        {
            return Users.FirstOrDefault(u => u.Id == id);
        }

        public static void Create(User user)
        {
            if (user != null && Users.Contains(user))
                Users.Add(user);
        }

        public static void Update(User user)
        {
            if (user != null && Users.Contains(user))
            {
                Delete(user);
                Create(user);
            }
        }
        public static void Delete(User user)
        {
            if (user != null)
                Users.Remove(user);

        }
    }
}
