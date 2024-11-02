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

        public PersonEntity? GetByEmail(string email) =>
            _dbContext.Persons.AsNoTracking().FirstOrDefault(x => x.Email == email);

        public PersonEntity Insert(PersonEntity person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return person;
        }
    }
}
