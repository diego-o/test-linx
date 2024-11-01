using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Register : ControllerBase
    {
        private readonly IRegisterService _registerService;

        public Register(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        public IActionResult NewAccount([FromBody] NewPersonModel newPerson)
        {
            _registerService.RegisterPerson(newPerson);
            return Created();
        }
    }
}
