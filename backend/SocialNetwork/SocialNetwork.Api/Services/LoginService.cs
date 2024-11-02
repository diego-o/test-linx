using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

namespace SocialNetwork.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly IPersonRepository _personRepository;

        public LoginService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public TokenViewModel Login(LoginViewModel login)
        {
            var person = _personRepository.GetByEmail(login.Email) ?? throw new ArgumentException("usuário não encontrado");

            VerifyPassword(login, person);

            var token = TokenService.GenerateJWTToken(person.Email);

            return new TokenViewModel
            {
                Token = token,
                Expires = DateTime.UtcNow.AddMinutes(TokenService.ExpiredTimeToken),
                ExpiresIn = TokenService.ExpiredTimeToken / 60,
                Issued = DateTime.UtcNow
            };
        }

        private static void VerifyPassword(LoginViewModel login, PersonEntity person)
        {
            var user = new User() { UserName = person.Email, PasswordHash = person.Password };

            var isValid = PasswordService.VerifyPassword(user, login.Password);
            if (!isValid)
                throw new ArgumentException("credenciais invalidas");
        }
    }
}
