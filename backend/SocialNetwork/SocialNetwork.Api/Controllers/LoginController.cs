using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.ViewModel;

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
        public async Task<TokenViewModel> LoginAsync([FromBody] LoginViewModel login) => 
            await _loginService.LoginAsync(login);
    }
}
