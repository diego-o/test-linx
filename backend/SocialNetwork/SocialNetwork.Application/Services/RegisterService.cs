using SocialNetwork.Application.Repositories;
using SocialNetwork.Application.Services.Interface;
using SocialNetwork.Application.ViewModel;
using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Services
{
    public class RegisterService : IRegisterService
    {
        private readonly IPersonRepository _personRepository;

        public RegisterService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public void RegisterPerson(NewPersonViewModel newPerson)
        {
            VerifyExists(newPerson);
            PersistPerson(newPerson);
        }

        private void PersistPerson(NewPersonViewModel newPerson)
        {
            newPerson = CriptPassword(newPerson);

            var personEntity = new PersonEntity(newPerson.Name, newPerson.Email, newPerson.Birth, newPerson.Password);
            _personRepository.Insert(personEntity);
        }

        private static NewPersonViewModel CriptPassword(NewPersonViewModel newPerson)
        {
            newPerson.Password = PasswordService.HashPassword(new User() { UserName = newPerson.Email }, newPerson.Password);
            return newPerson;
        }

        private void VerifyExists(NewPersonViewModel newPerson)
        {
            var personExist = _personRepository.GetByEmail(newPerson.Email);

            if (personExist is not null)
                throw new ArgumentException("E-mail já cadastrado");
        }
    }
}
