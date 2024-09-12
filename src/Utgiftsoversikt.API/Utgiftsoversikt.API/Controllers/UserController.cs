using System;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using Utgiftsoversikt.Service;

namespace Utgiftsoversikt.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        //private readonly UserService _userService;

        

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }
        // Return user with id
        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(int id)
        {
            var user = UserService.FindAllUsers().FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return user;
        }
        // Returns all users
        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<User>> Get()
        {
            var user = UserService.FindAllUsers();
            if (user == null)
                return NotFound();
            return user;
        }
        // Create a new user
        [HttpPost(Name = "PostUsers")]
        public IActionResult Post(User user)
        
        // Add a user to the database
        {
            UserService.Create(user);
            return CreatedAtAction(
                nameof(Get), new 
                { 
                    id = user.Id, 
                    name = user.Name, 
                    age = user.Age 
                }, 
                user);
        }
        // Updates a user
        [HttpPut("{id}", Name = "PutUsers")]
        public ActionResult Put(int id, User user)
        {
            if (user.Id != id)
                return BadRequest();
            var orgUser = UserService.FindUserById(id);
            if (orgUser == null)
                return NotFound();

            UserService.Update(user);
            return NoContent();
        }
        // Delete a user
        [HttpDelete("{id}", Name = "DeleteUsers")]
        public ActionResult Delete(int id)
        {
            System.Diagnostics.Debug.WriteLine($"Before: {UserService.FindAllUsers().Count()}");
            var user = UserService.FindUserById(id);
            if (user == null)
                return NotFound();

            UserService.Delete(user);
            System.Diagnostics.Debug.WriteLine($"After: {UserService.FindAllUsers().Count()}");
            return NoContent();
        }
    }
}