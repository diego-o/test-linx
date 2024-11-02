using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.Structures;
using SocialNetwork.Application.ViewModel;

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
        public IActionResult PostMessage([FromBody] PostMessageViewModel postMessage)
        {
            _personFeedService.PostMessage(postMessage);
            return Created();
        }

        [HttpPost("paged")]
        public PageResult FeedPaged([FromBody] PageQuery pageQuery) =>
            _personFeedService.Paged(pageQuery);
    }
}
