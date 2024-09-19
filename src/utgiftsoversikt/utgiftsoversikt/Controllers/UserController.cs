using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;
using utgiftsoversikt.Repos;
using utgiftsoversikt.Services;


namespace Utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        // Return user with id
        [HttpGet("{name}", Name = "GetUser")]
        public ActionResult<User> Get(string name)
        {
            var user = _userService.GetUserByEmail(name);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // Returns all users
        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<User>> Get()
        {
            var users = _userService.FindAllUsers();
            return users;
        }
        // Create a new user
        [HttpPost(Name = "PostUsers")]
        public IActionResult Post(User user)
        {
            _userService.CreateUser(user);
            return Ok(user.Id);            
        }

        [HttpPut(Name = "PutUsers")]
        public ActionResult Put(User user)
        {
            if (!_userService.IdExist(user.Id))
                return BadRequest();

            _userService.UpdateUser(user);
            return NoContent();
        }
        // Delete a user
        [HttpDelete("{id}", Name = "DeleteUsers")]
        public ActionResult Delete(string id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            _userService.DeleteUser(user);
            return NoContent();
        }
    }
}