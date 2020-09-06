using System;
using user_service.Controllers;
using user_service.Core.Services;
using user_service.Core.Interfaces;
using Xunit;
using Microsoft.Extensions.Logging;
using Moq;
using user_service.Core.Dtos;

namespace user_service_test
{
    public class UserServiceTest
    {

        private void setEnvironmentVariable()
        {
            // Arrange
            Environment.SetEnvironmentVariable("USERS.REST.URL", "https://jsonplaceholder.typicode.com/users");

        }

        [Fact]
        public void GetAllUsers()
        {
            //Arrange
            setEnvironmentVariable();
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);

            //Act
            var users = user_service.getAllUsers();
            Console.WriteLine(users[0].Id);

            //Assert
            Assert.Equal(10, users.Count);

        }

        [Fact]
        public void GetUserById()
        {
            //Arrange
            setEnvironmentVariable();
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);
            int _id = 2;

            //Act
            var user = user_service.getUserbyId(_id);
            Console.WriteLine(user.Id);

            //Assert
            Assert.Equal(_id, user.Id);

        }

        [Fact]
        public void createUser()
        {
            //Arrange
            setEnvironmentVariable();
            var mock = new Mock<ILogger<UserService>>();
            IUserService user_service = new UserService(mock.Object);
            int _id = 11;
            string name = "Phielo philic";

            User new_user = new User(name);
            //Act
            var user = user_service.createNewUser(new_user);

            //Assert
            Assert.Equal(_id, user.Id);
            Assert.Equal(name, user.Name);

        }
    }
}
