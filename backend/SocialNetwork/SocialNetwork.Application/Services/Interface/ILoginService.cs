using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface ILoginService
    {
        Task<TokenViewModel> LoginAsync(LoginViewModel login);
    }
}
