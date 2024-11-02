using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IPersonFeedService _personFeedService;

        public MessageController(IPersonFeedService personFeedService)
        {
            _personFeedService = personFeedService;
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] PostMessageModel postMessage)
        {
            _personFeedService.PostMessage(postMessage);
            return Created();
        }
    }
}
