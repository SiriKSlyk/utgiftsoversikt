using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Models;


namespace Utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UserService _userService;



        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        // Return user with id
        
        // Returns all users
        [HttpGet(Name = "GetUsers")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var user = await _userService.GetAllUsersAsync();
            if (user == null)
                return NotFound();
            
            return Ok(user);
        }
        
    }
}