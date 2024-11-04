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
        public async Task<IActionResult> PostMessageAsync([FromBody] PostMessageViewModel postMessage)
        {
            await _personFeedService.PostMessageAsync(postMessage);
            return Created(string.Empty, null);
        }

        [HttpPost("paged")]
        public async Task<PageResult> FeedPaged([FromBody] PageQuery pageQuery) =>
            await _personFeedService.PagedAsync(pageQuery);
    }
}
