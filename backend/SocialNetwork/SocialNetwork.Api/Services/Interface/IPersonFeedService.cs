using SocialNetwork.Api.ViewModel;
using SocialNetwork.Infrastructure.Structures;

namespace SocialNetwork.Api.Services.Interface
{
    public interface IPersonFeedService
    {
        void PostMessage(PostMessageModel postMessage);
        PageResult Paged(PageQuery pageQuery);
    }
}
