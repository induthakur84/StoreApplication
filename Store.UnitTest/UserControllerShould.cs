using NSubstitute;
using Order.API.Controllers;
using Order.Data.Interfaces;
using Order.DTO.DTO.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Order.DTO.DTO.Request;
using System.Security.Policy;

namespace Store.UnitTest
{
    public class UserControllerShould
    {
        private readonly IUserService _userMock;
        private readonly UserController _userController;

        public UserControllerShould()
        {
            // Arrange
            _userMock = Substitute.For<IUserService>();
            _userController = new UserController(_userMock);
        }

        [Fact]
        public async Task GivenRequest_WhenGetAll_ThenReturnUsers()
        {
            // Arrange
            var users = new List<UserResponse>
            {
                new UserResponse
                {
                    Id = 1,
                    Name = "John Doe",
                    Email = "ram@gmail.com"
                },
                new UserResponse
                {
                    Id = 2,
                    Name = "Jane Smith",
                    Email = "ram12@gmail.com"
                }
            };

            _userMock.GetAll().Returns(users);

            // Act
            var result = await _userController.GetAll();

            // Assert
            result.Should().NotBeNull();

            var okResult = Assert.IsType<OkObjectResult>(result);

            var data = Assert.IsAssignableFrom<IEnumerable<UserResponse>>(okResult.Value);

            data.Should().HaveCount(2);

            await _userMock.Received(1).GetAll();
        }

        [Fact]
        public async Task GivenRequest_WhenGetById_ThenReturnNotFound()
        {
            // Arrange
            _userMock.GetById(1).Returns((UserResponse?)null);

            // Act
            var result = await _userController.GetById(1);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);

            await _userMock.Received(1).GetById(1);
        }



        [Fact]

        public async Task GivenRequest_WhenGetById_ThenReturnUser()
        {
            // Arrange
            var user = new UserResponse
            {
                Id = 1,
                Name = "John Doe",
                Email = "ram@gmail.com"
            };

            _userMock.GetById(1).Returns(user);
            //Act

            var result = await _userController.GetById(1);
            ///Assert

            result.Should().NotBeNull();
            var okResult = Assert.IsType<OkObjectResult>(result);
            okResult.Value.Should().BeEquivalentTo(user);
            await _userMock.Received(1).GetById(1);
        }

        #region Create Tests

        [Fact]
        public async Task GivenRequest_WhenCreate_ThenReturnCreateUser()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Name = "John Doe",
                Email = "ram@gmail.com"
            };

            var userResponse = new UserResponse
            {
                Id = 1,
                Name = "John Doe",
                Email = "ram@gmail.com"
            };

            _userMock.Create(userRequest).Returns(userResponse);



            //Act   

            var result = await _userController.Create(userRequest);



            ///Assert
            ///
            var okResult = Assert.IsType<OkObjectResult>(result);

            okResult.Value.Should().BeEquivalentTo(userResponse);

        }

        #endregion





        [Fact]
        public async Task GivenValidRequest_WhenUpdate_ThenReturnUpdatedUser()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Name = "John Doe Updated",
                Email = "update@gmail.com"
            };

            var response = new UserResponse
            {
                Id = 1,
                Name = "John Doe Updated",
                Email = "update@gmail.com",
            };

            _userMock.Update(1, userRequest).Returns(response);


            //Act

            var result = await _userController.Update(1, userRequest);


            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);

            okResult.Value.Should().BeEquivalentTo(response);
        }


        //Delete Tests  

        [Fact]
        public async Task GivenValidRequest_WhenDelete_ThenReturnTrue()
        {
            // Arrange
            _userMock.Delete(1).Returns(true);
            // Act
            var result = await _userController.Delete(1);
            // Assert
            Assert.IsType<OkObjectResult>(result);
            await _userMock.Received(1).Delete(1);
        }
       

    }
}