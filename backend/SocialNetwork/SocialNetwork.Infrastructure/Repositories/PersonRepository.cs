using Microsoft.EntityFrameworkCore;
using SocialNetwork.Domain.Entities;
using SocialNetwork.Infrastructure.Context.Interfaces;
using SocialNetwork.Infrastructure.Repositories.Interfaces;

namespace SocialNetwork.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly ISocialNetworkDataContext _dbContext;

        public PersonRepository(ISocialNetworkDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(PersonEntity person)
        {
            _dbContext.Persons.Remove(person);
            _dbContext.SaveChanges();
        }

        public PersonEntity? GetById(int id) =>
            _dbContext.Persons.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public PersonEntity Insert(PersonEntity person)
        {
            _dbContext.Persons.Add(person);
            _dbContext.SaveChanges();
            return person;
        }

        public PersonEntity Update(PersonEntity person)
        {
            throw new NotImplementedException();
        }
    }
}
