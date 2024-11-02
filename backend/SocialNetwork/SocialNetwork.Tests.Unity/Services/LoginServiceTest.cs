using NSubstitute;
using NSubstitute.ExceptionExtensions;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Tests.Unity.Fakers;

namespace SocialNetwork.Tests.Unity.Services
{
    public class LoginServiceTest
    {
        private readonly ILoginService _loginService = Substitute.For<ILoginService>();

        [Fact]
        public async Task LoginAsync_Sucess()
        {
            //Arrange
            var login = LoginViewModelFaker.LoginViewModelFake();
            _loginService.LoginAsync(login).Returns(TokenViewModelFaker.TokenViewModelFake());

            //Act
            var loginResult = await _loginService.LoginAsync(login);

            //Assert
            Assert.False(string.IsNullOrWhiteSpace(loginResult.Token));
        }

        [Fact]
        public void LoginAsync_User_Not_Found()
        {
            //Arrange
            var login = LoginViewModelFaker.LoginViewModelFake();
            _loginService.LoginAsync(login).Throws(new ArgumentException("usuário não encontrado"));

            //Act
            var exception = Record.ExceptionAsync(async () => await _loginService.LoginAsync(login));

            //Assert
            Assert.NotNull(exception);
            Assert.Equal("usuário não encontrado", exception.Result?.Message);
        }

        [Fact]
        public void LoginAsync_Credentials_Invalid()
        {
            //Arrange
            var login = LoginViewModelFaker.LoginViewModelFake();
            _loginService.LoginAsync(login).Throws(new ArgumentException("credenciais invalidas"));

            //Act
            var exception = Record.ExceptionAsync(async () => await _loginService.LoginAsync(login));

            //Assert
            Assert.NotNull(exception);
            Assert.Equal("credenciais invalidas", exception.Result?.Message);
        }
    }
}
