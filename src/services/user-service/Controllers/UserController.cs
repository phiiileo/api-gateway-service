using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using user_service.Core.Dtos;
using user_service.Core.Services;

namespace user_service.Controllers
{
    [Route("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserController()
        {
        }

        [HttpGet]
        [Route("users")]
        public ActionResult<List<User>> GetAllUsers()
        {
            var _User = new UserService();
           
            List<User> users = _User.getAllUsers();

            return Ok(users);
        }
    }
}
