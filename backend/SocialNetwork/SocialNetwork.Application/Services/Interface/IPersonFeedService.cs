using SocialNetwork.Application.Structures;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface IPersonFeedService
    {
        Task PostMessageAsync(PostMessageViewModel postMessage);
        Task<PageResult> PagedAsync(PageQuery pageQuery);
    }
}
