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
        [HttpGet]
        [Route("/user/{mail}")]
        public ActionResult<User> Get(string mail)
        {
            var user = _userService.GetUserByEmail(mail);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // Returns all users
        [HttpGet]//(Name = "GetUsers")]
        [Route("/users")]
        public ActionResult<List<User>> Get()
        {
            var users = _userService.FindAllUsers();
            return users;
        }
        // Create a new user
        [HttpPost]//(Name = "PostUser")]
        [Route("/user")]
        public IActionResult Post(User user)
        {
            _userService.CreateUser(user);
            return Ok(user.Id);            
        }

        [HttpPut]//(Name = "PutUser")]
        [Route("/user")]
        public ActionResult Put(User user)
        {
            if (!_userService.IdExist(user.Id))
                return BadRequest();

            _userService.UpdateUser(user);
            return NoContent();
        }
        // Delete a user
        [HttpDelete]//("{id}", Name = "DeleteUser")]
        [Route("/user")]
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