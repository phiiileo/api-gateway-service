using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.Extensions.Logging;
using user_service.Core.Dtos;
using user_service.Core.Interfaces;
using RestSharp;
using user_service.Core.Services;

namespace user_service.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _user;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService user,ILogger<UserController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        public ActionResult<List<User>> GetAllUsers()
        {
            List<User> users = _user.getAllUsers();
            if(users == null)
            {
              var error = new NoDataException();
                return BadRequest(error);
            }
            return Ok(users);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<User> GetUserById(int id)
        {

            if(typeof(int) == id.GetType())
            {
                 User user = _user.getUserbyId(id);
                if (_user == null)
                {
                    var error = new ErrorObject("There is no user wthis id");
                    return NotFound(error);
                }
                return Ok(user);
            }
            else
            {
                var error = new ErrorObject("Id is not a valid number");
                return BadRequest(error);
            }
         
        }


        [HttpPost]
        [Route("")]
        public ActionResult <User> createNewUser([FromBody] User body)
        {
           var new_User =  _user.createNewUser(body);
            Console.WriteLine(new_User);
            if(new_User != null)
            {
                new_User.Name = body.Name;
            return Ok(new_User);
            }
            var error = new ErrorObject("Something went wrong!");
            return BadRequest(error);
        }

        [HttpPost]
        [Route("discount/check")]
        public ActionResult<User> CheckDiscount([FromBody] User body)
        {
            var status = Request.HttpContext.Items["discount"];
            return Ok(new DiscountDto(body.DiscountId, (string)status));
        }
    }
}
