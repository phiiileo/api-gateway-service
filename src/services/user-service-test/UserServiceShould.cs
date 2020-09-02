using System;
using user_service.Controllers;
using user_service.Core.Services;
using user_service.Core.Interfaces;
using Xunit;

namespace user_service_test
{
    public class UserServiceTest
    {
        [Fact]
        public void GetAllUsers()
        {
            Environment.SetEnvironmentVariable("USERS.REST.URL", "https://jsonplaceholder.typicode.com/users");

            IUserService user_service = new UserService();
            var users = user_service.getAllUsers();
            Console.WriteLine(users[0].id);

            Assert.Equal(10, users.Count);

        }
    }
}
