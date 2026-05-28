using NSubstitute;
using Order.API.Controllers;
using Order.Data.Interfaces;
using Order.DTO.DTO.Request;
using Order.DTO.DTO.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Store.UnitTest
{
    public class UserControllerShould
    {

        private readonly IUserService _userMock;

        private readonly UserController _userController;
        public UserControllerShould(IUserService userService)
        {
            //Arrange
            _userMock = Substitute.For<IUserService>();
            _userController = new UserController(_userMock);
        }

        [Fact]
        public async Task GivenRequest_WhenGetAll_ThenReturnReturnUsers()
        {
            //AAA triple A pattern


            //Arrange the data and the mock behavior

            //Act

            //Assert    



            //Arrange the data and the mock behavior    


            var users = new List<UserResponse>
            {

                new UserResponse { Id = 1, Name = "John Doe", Email = "ram@gmail.com" },
                new UserResponse { Id = 2, Name = "Jane Smith", Email = "ram12@gmail.com" }
            };

            _userMock.GetAll().Returns(users);




            //Act
            var result = await _userController.GetAll();



            //Assert
            result.Should().NotBeNull();

            //var okResult= Assert.IsType<OkObjectResult>(result);

            //var data= Assert.IsAssignableFrom<IEnumerable<UserResponse>>(okResult.Value);

            //data.Should().HaveCount(2);

            await _userMock.Received(1).GetAll();
        }


        [Fact]
        public async Task GivenRequest_WhenGetById_ThenNOTFoundindatabase()
        {

            //arrange
            _userMock.GetById(1).Returns((UserResponse?)null);

            //act
            var result = await _userController.GetById(1);


            //assert

            Assert.IsType<NotFoundResult>(result);
            await _userMock.Received(1).GetById(1);

        }
    }
    }