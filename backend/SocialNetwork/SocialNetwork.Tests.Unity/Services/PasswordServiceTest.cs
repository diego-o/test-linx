using SocialNetwork.Application.Services;

namespace SocialNetwork.Tests.Unity.Services
{
    public class PasswordServiceTest
    {
        private string _password = "asd#@H987876";
        private string _username = "username";

        [Fact]
        public void GenerateHashPassword_Sucess()
        {
            //Arrange
            var newUser = new User() { UserName = _username };

            //Act
            var hash = PasswordService.HashPassword(newUser, _password);

            Assert.False(string.IsNullOrWhiteSpace(hash));
        }

        [Fact]
        public void VerifyHashPassword() 
        {
            //Arrange
            var newUser = new User() { UserName = _username };
            var hash = PasswordService.HashPassword(newUser, _password);

            var userHash = new User() { PasswordHash = hash, UserName = _username };

            //Act
            var isValid = PasswordService.VerifyPassword(userHash, _password);

            //Assert
            Assert.True(isValid);
        }
    }
}
