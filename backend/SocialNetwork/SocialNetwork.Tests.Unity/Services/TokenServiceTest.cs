using Microsoft.Extensions.Configuration;
using SocialNetwork.Application.Services;
using SocialNetwork.Application.Services.Interface;

namespace SocialNetwork.Tests.Unity.Services
{
    public class TokenServiceTest
    {
        private readonly ITokenService _tokenService;
        private readonly IConfiguration _configuration;

        private string _username = "username";
        private int _userId = 123;

        public TokenServiceTest()
        {
            _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            _tokenService = new TokenService(_configuration);
        }

        [Fact]
        public void Generate_Token()
        {
            //Arrange & Act
            var token = _tokenService.GenerateJWTToken(_username, _userId);

            //Assert
            Assert.NotNull(token);
        }

        [Fact]
        public void Generate_Token_and_Check()
        {
            //Arrange
            var token = _tokenService.GenerateJWTToken(_username, _userId);

            //Act
            var isValid = _tokenService.ValidateToken(token);

            //Assert
            Assert.NotNull(token);
            Assert.NotNull(isValid);
        }

        [Fact]
        public void Generate_Token_and_Invalidate()
        {
            //Arrange
            var token = _tokenService.GenerateJWTToken(_username, _userId);
            token = token.Replace("e", "a");

            //Act
            var exception = Record.Exception(() => _tokenService.ValidateToken(token));

            //Assert
            Assert.NotNull(token);
            Assert.Equal("token invalido", exception.Message);
        }
    }
}
