using ComonTecApi.Application.IServices;
using ComonTecApi.Domain.Entities;
using ComonTecApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Moq;

namespace Application.UnitTests
{
    public class AuthServiceFacts
    {
        private Mock<IAuthService> _mockAuthService = new Mock<IAuthService>();
        private Mock<IJwtService> _mockIJwtService = new Mock<IJwtService>();

        [Fact]
        public async Task ShouldRegisterUser()
        {
            var user = new UserDto()
            {
                Username = "testuser",
                Password = "testpword"
            };

            var responseString = "Successfully created User";

            var okResult = TypedResults.Ok(responseString);

            _mockAuthService
                .Setup(service => service.RegisterUser(user))
                .ReturnsAsync(okResult);

            var result = await _mockAuthService.Object.RegisterUser(user);
            var resultResponseMsg = ((Ok<string>)result.Result).Value;

            Assert.True(result.Result is Ok<string>, "Expected Ok<string> result");
            Assert.Equal(responseString, resultResponseMsg);
        }

        [Fact]
        public async Task ShouldLoginUser()
        {
            var userDto = new UserDto()
            {
                Username = "testuser",
                Password = "testpword"
            };

            var user = new User()
            {
                Id = 1,
                Username = userDto.Username,
                Password = userDto.Password
            };

            var expectedToken = "thisisatesttoken";

            var okResult = TypedResults.Ok(expectedToken);

            _mockAuthService
                .Setup(service => service.Login(userDto))
                .ReturnsAsync(okResult);

            _mockIJwtService
                .Setup(service => service.CreateToken(user))
                .Returns("thisisatesttoken");

            var resultToken = _mockIJwtService.Object.CreateToken(user);
            var result = await _mockAuthService.Object.Login(userDto);
            var resultResponseMsg = ((Ok<string>)result.Result).Value;

            Assert.True(result.Result is Ok<string>, "Expected Ok<string> result");
            Assert.Equal(expectedToken, resultToken);
            Assert.Equal(resultResponseMsg, expectedToken);
        }
    }
}
