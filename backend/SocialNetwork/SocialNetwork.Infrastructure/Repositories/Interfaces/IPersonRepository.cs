using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Infrastructure.Repositories.Interfaces
{
    public interface IPersonRepository
    {
        PersonEntity Insert(PersonEntity person);
        PersonEntity Update(PersonEntity person);
        void Delete(PersonEntity person);
        PersonEntity? GetById(int id);
    }
}
