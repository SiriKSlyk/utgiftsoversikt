using Microsoft.EntityFrameworkCore;
using utgiftsoversikt.Models;
using utgiftsoversikt.Services;

public interface IUserService
{
    Task<IEnumerable<User>> GetAllUsersAsync();

}

public class UserService : IUserService
{
    private readonly UserDbContext _context;

    public UserService(UserDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.User.ToListAsync();
    }
}
