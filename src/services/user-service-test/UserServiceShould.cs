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

        private void setEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("USERS.REST.URL", "https://jsonplaceholder.typicode.com/users");

        }

        [Fact]
        public void GetAllUsers()
        {
            setEnvironmentVariable();
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);
            var users = user_service.getAllUsers();
            Console.WriteLine(users[0].Id);

            Assert.Equal(10, users.Count);

        }

        [Fact]
        public void GetUserById()
        {
            setEnvironmentVariable();
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);
            int _id = 2;
            var user = user_service.getUserbyId(_id);
            Console.WriteLine(user.Id);

            Assert.Equal(_id, user.Id);

        }
    }
}
