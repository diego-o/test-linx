using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface IRegisterService
    {
        Task RegisterPersonAsync(NewPersonViewModel newPerson);
    }
}
