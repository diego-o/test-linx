using Microsoft.EntityFrameworkCore;
using SocialNetwork.Application.Repositories;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;

namespace SocialNetwork.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ISocialNetworkDataContext _dbContext;

        public PersonRepository(ISocialNetworkDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonEntity?> GetByEmailAsync(string email) =>
            await _dbContext.Persons.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);

        public async Task<PersonEntity> InsertAsync(PersonEntity person)
        {
            await _dbContext.Persons.AddAsync(person);
            await _dbContext.SaveChangesAsync();
            return person;
        }
    }
}
