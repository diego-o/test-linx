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

        public async Task RegisterPersonAsync(NewPersonViewModel newPerson)
        {
            await VerifyExistsAsync(newPerson);
            await PersistPersonAsync(newPerson);
        }

        private async Task PersistPersonAsync(NewPersonViewModel newPerson)
        {
            newPerson = CriptPassword(newPerson);

            var personEntity = new PersonEntity(newPerson.Name, newPerson.Email, newPerson.Birth, newPerson.Password);
            await _personRepository.InsertAsync(personEntity);
        }

        private static NewPersonViewModel CriptPassword(NewPersonViewModel newPerson)
        {
            newPerson.Password = PasswordService.HashPassword(new User() { UserName = newPerson.Email }, newPerson.Password);
            return newPerson;
        }

        private async Task VerifyExistsAsync(NewPersonViewModel newPerson)
        {
            var personExist = await _personRepository.GetByEmailAsync(newPerson.Email);

            if (personExist is not null)
                throw new ArgumentException("E-mail já cadastrado");
        }
    }
}
