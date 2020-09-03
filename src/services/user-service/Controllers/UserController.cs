using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using user_service.Core.Dtos;
using user_service.Core.Interfaces;
using user_service.Core.Services;

namespace user_service.Controllers
{
    [Route("api")]
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

            return Ok(users);
        }
    }
}
