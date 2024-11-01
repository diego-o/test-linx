using SocialNetwork.Api.Services.Interface;
using SocialNetwork.Api.ViewModel;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

namespace SocialNetwork.Api.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IPersonRepository _personRepository;

        public RegisterService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void RegisterPerson(NewPersonModel newPerson)
        {
            try
            {
                var personEntity = new PersonEntity(newPerson.Name, newPerson.Email, newPerson.Birth, newPerson.Password);
                _personRepository.Insert(personEntity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
