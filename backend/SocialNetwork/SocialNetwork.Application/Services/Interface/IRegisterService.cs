using SocialNetwork.Application.ViewModel;

namespace SocialNetwork.Application.Services.Interface
{
    public interface IRegisterService
    {
        void RegisterPerson(NewPersonViewModel newPerson);
    }
}
