using System;
using user_service.Controllers;
using user_service.Core.Services;
using user_service.Core.Interfaces;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;

namespace user_service_test
{
    public class UserServiceTest
    {
        [Fact]
        public void GetAllUsers()
        {
            Environment.SetEnvironmentVariable("USERS.REST.URL", "https://jsonplaceholder.typicode.com/users");
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);
            var users = user_service.getAllUsers();
            Console.WriteLine(users[0].Id);

            Assert.Equal(10, users.Count);

        }
    }
}
