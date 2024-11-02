using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface ILoginService
    {
        TokenViewModel Login(LoginViewModel login);
    }
}
