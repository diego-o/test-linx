using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Services.Interface
{
    public interface ILoginService
    {
        TokenViewModel Login(LoginViewModel login);
    }
}
