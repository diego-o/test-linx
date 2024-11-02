using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        private readonly IPersonFeedService _personFeedService;

        public FeedController(IPersonFeedService personFeedService)
        {
            _personFeedService = personFeedService;
        }

        [HttpPost]
        public IActionResult PostMessage([FromBody] PostMessageModel postMessage)
        {
            _personFeedService.PostMessage(postMessage);
            return Created();
        }

        [HttpPost("paged")]
        public PageResult FeedPaged([FromBody] PageQuery pageQuery) =>
            _personFeedService.Paged(pageQuery);
    }
}
