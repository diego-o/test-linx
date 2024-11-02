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
            VerifyExists(newPerson);
            PersistPerson(newPerson);
        }

        private void PersistPerson(NewPersonModel newPerson)
        {
            newPerson = CriptPassword(newPerson);

            var personEntity = new PersonEntity(newPerson.Name, newPerson.Email, newPerson.Birth, newPerson.Password);
            _personRepository.Insert(personEntity);
        }

        private static NewPersonModel CriptPassword(NewPersonModel newPerson)
        {
            newPerson.Password = PasswordService.HashPassword(new User() { UserName = newPerson.Email }, newPerson.Password);
            return newPerson;
        }

        private void VerifyExists(NewPersonModel newPerson)
        {
            var personExist = _personRepository.GetByEmail(newPerson.Email);

            if (personExist is not null)
                throw new ArgumentException("E-mail já cadastrado");
        }
    }
}
