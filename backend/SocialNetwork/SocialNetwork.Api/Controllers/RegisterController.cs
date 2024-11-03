using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public async Task<IActionResult> NewAccountAsync([FromBody] NewPersonViewModel newPerson)
        {
            await _registerService.RegisterPersonAsync(newPerson);
            return Created(string.Empty, null);
        }
    }
}
