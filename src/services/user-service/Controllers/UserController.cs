using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using user_service.Core.Dtos;
using user_service.Core.Interfaces;
using user_service.Core.Services;

namespace user_service.Controllers
{
    [Route("api/v1/dummy")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService user;

        public UserController(IUserService User)
        {
            user = User;
        }

        [HttpGet]
        [Route("users")]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = user.getAllUsers();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("users/{id}")]
        public ActionResult<User> GetUserById(int id)
        {

            if(typeof(int) == id.GetType())
            {
                 User _user = user.getUserbyId(id);
                if (_user == null)
                {
                    return NotFound();
                }
                return Ok(_user);
            }
            else
            {
                var error = "Error: Id is not a valid number";
                return BadRequest(error);
            }
         
        }
    }
}
