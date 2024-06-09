// Controllers/UsersController.cs
using Microsoft.AspNetCore.Mvc;
using UserRegistrationApi.Data.Repositories.IRepository;
using UserRegistrationApi.Models;

namespace UserRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly List<User> _usersInMemory = new List<User>();


        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult RegisterUser(User user)
        {
            _userRepository.AddUser(user);
            _userRepository.SaveChanges();
            _usersInMemory.Add(user);

            return Ok("User registered successfully!");
        }

        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userRepository.GetUserById(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }
        [HttpGet("all-in-memory")]
        public IActionResult GetAllUsersInMemory()
        {
          

            return Ok(_usersInMemory);
        }

        [HttpGet("all-from-database")]
        public IActionResult GetAllUsersFromDatabase()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("ordered-by-username")]
        public IActionResult GetUsersOrderedByUsername()
        {
            var users = _userRepository.GetAllUsersOrderedByUsername();
            return Ok(users);
        }

        [HttpGet("grouped-by-role")]
        public IActionResult GetUsersGroupedByRole()
        {
            var usersGroupedByRole = _userRepository.GetUsersGroupedByRole();
            return Ok(usersGroupedByRole);
        }
    }
}
