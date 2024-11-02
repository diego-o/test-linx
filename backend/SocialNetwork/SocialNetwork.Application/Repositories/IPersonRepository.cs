using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Repositories
{
    public interface IPersonRepository
    {
        PersonEntity Insert(PersonEntity person);
        PersonEntity? GetByEmail(string email);
    }
}
