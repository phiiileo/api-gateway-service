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
                    return NotFound("There is no user with this id");
                }
                return Ok(_user);
            }
            else
            {
                var error = "Error: Id is not a valid number";
                return BadRequest(error);
            }
         
        }

        [HttpPost]
        [Route("users")]
        public ActionResult<User> createNewUser([FromBody] User body)
        {
           var new_User =  user.createNewUser(body);
            Console.WriteLine(new_User);
            if(new_User != null)
            {
                new_User.Name = body.Name;
            return Ok(new_User);
            }
            return BadRequest();
        }
    }

    public class userObject
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public userObject(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
