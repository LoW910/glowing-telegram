#nullable disable
using Microsoft.AspNetCore.Mvc;
using ElkPrep.Shared;
using ElkPrep.Server.Interfaces;

namespace ElkPrep.Server.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _IUser;

        public UserController(IUser iUser)
        {
            _IUser = iUser;

        }

        // Get list of all users
        [HttpGet("")]
        public async Task<List<User>> GetUsers()
        {
            return await Task.FromResult(_IUser.GetAllUsers());
        }

        // Get user by id
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            User user = _IUser.GetUser(id);
            if (user != null)
            {
                return user;
            }
            return NotFound();
        }

        // Create User
        [HttpPost("add")]
        public void CreateUser(User user)
        {
            Console.WriteLine(user);
            _IUser.AddUser(user);
        }

        // Update User
        [HttpPut("update/{id}")]
        public void UpdateUser(User user)
        {
            _IUser.UpdateUser(user);
        }

        // Delete User
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}
