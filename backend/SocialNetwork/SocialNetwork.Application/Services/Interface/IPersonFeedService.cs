using SocialNetwork.Application.Structures;
using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface IPersonFeedService
    {
        void PostMessage(PostMessageViewModel postMessage);
        PageResult Paged(PageQuery pageQuery);
    }
}
