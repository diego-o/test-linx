using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.ViewModel;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IPersonRepository _personRepository;
        private readonly ITokenService _tokenService;

        public LoginService(IPersonRepository personRepository, ITokenService tokenService)
        {
            _personRepository = personRepository;
            _tokenService = tokenService;
        }

        public TokenViewModel Login(LoginViewModel login)
        {
            var person = _personRepository.GetByEmail(login.Email) ?? throw new ArgumentException("usuário não encontrado");

            VerifyPassword(login, person);

            var token = _tokenService.GenerateJWTToken(person.Email, person.Id);

            return new TokenViewModel
            {
                Token = token,
                Expires = DateTime.UtcNow.AddMinutes(_tokenService.ExpiredTimeToken()),
                ExpiresIn = _tokenService.ExpiredTimeToken() / 60,
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
