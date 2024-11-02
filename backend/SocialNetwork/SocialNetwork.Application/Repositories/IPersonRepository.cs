using SocialNetwork.Domain.Entities;

namespace SocialNetwork.Application.Repositories
{
    public interface IPersonRepository
    {
        Task<PersonEntity> InsertAsync(PersonEntity person);
        Task<PersonEntity?> GetByEmailAsync(string email);
    }
}
