using System;
using Microsoft.AspNetCore.Mvc;
using Utgiftsoversikt.Service;

namespace Utgiftsoversikt.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        //private readonly UserService _userService;

        

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(int id)
        {
            var user = UserService.FindAllUsers().FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            return user;
        }

        [HttpGet(Name = "GetUsers")]
        public ActionResult<List<User>> Get()
        {
            var user = UserService.FindAllUsers();
            if (user == null)
                return NotFound();
            return user;
        }
    }
}