using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Services.Interface
{
    public interface IPersonFeedService
    {
        void PostMessage(PostMessageModel postMessage);
    }
}
