#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ElkPrep.Server.DAL;
using ElkPrep.Shared;
using ElkPrep.Server.Interface;

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
            User user = _IUser.GetUserData(id);
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
            _IUser.AddUser(user);
        }

        // Update User
        [HttpPut("/update/{id}")]
        public void UpdateUser(User user)
        {
            _IUser.UpdateUser(user);
        }

        // Delete User
        [HttpDelete("/delete/{id}")]
        public IActionResult Delete(int id)
        {
            _IUser.DeleteUser(id);
            return Ok();
        }
    }
}
