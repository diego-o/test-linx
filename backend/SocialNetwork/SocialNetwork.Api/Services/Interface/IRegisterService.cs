using SocialNetwork.Api.ViewModel;

namespace SocialNetwork.Api.Services.Interface
{
    public interface IRegisterService
    {
        void RegisterPerson(NewPersonModel newPerson);
    }
}
