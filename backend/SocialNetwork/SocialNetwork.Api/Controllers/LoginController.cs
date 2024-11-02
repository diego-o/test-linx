using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public TokenViewModel Login([FromBody] LoginViewModel login) => 
            _loginService.Login(login);
    }
}
