using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using utgiftsoversikt.Data;
using utgiftsoversikt.Models;


namespace Utgiftsoversikt.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(CosmosContext context, ILogger<UsersController> logger) : ControllerBase
    {
        //private readonly CosmosContext context = new CosmosContext();

        // Return user with id
        [HttpGet("{name}", Name = "GetUser")]
        public ActionResult<User> Get(string name)
        {
            var user = context.Users.FirstOrDefault(u => u.Name == name);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
        // Returns all users
        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<User>> Get()
        {
            // Create a demo user
            var users = context.Users?.ToList();
            return users;
        }
        // Create a new user
        [HttpPost(Name = "PostUsers")]
        public async Task<IActionResult> Post(User user)

        // Add a user to the database
        {
            var newUser = new User() { Name = user.Name };
            var resulat = context.Users?.Add(newUser);
            await context.SaveChangesAsync();
            return Ok(newUser.Id);
            
        }
        // Updates a user
        /*[HttpPut("{id}", Name = "PutUsers")]
        public ActionResult Put(string id, User user)
        {
            if (user.Id != id)
                return BadRequest();
            var orgUser = Get(id);
            if (orgUser == null)
                return NotFound();

            UserService.Update(user);
            return NoContent();
        }
        // Delete a user
        [HttpDelete("{id}", Name = "DeleteUsers")]
        public ActionResult Delete(string id)
        {
            System.Diagnostics.Debug.WriteLine($"Before: {UserService.FindAllUsers().Count()}");
            var user = UserService.FindUserById(id);
            if (user == null)
                return NotFound();

            UserService.Delete(user);
            System.Diagnostics.Debug.WriteLine($"After: {UserService.FindAllUsers().Count()}");
            return NoContent();
        }*/
    }
}