using SocialNetwork.Domain.Resources;
using System.Text.RegularExpressions;

namespace SocialNetwork.Domain.Entities
{
    public class PersonEntity : EntityBase
    {   
        public string Name { get; private set; }
        public string Email { get; set; }
        public DateTime Birth { get; private set; }
        public string Password { get; private set; }

        public List<PersonFeedEntity> Feed { get; set; }

        public PersonEntity() { }

        public PersonEntity(string nome, string email, DateTime birth, string password)
        {
            Name = nome;
            Email = email;
            Birth = birth;
            Password = password;

            ValidatePerson();
        }

        private void ValidatePerson()
        {
            ValidateName();
            ValidateEmail();
            ValidateBirth();
        }

        private void ValidateName()
        {
            if (string.IsNullOrWhiteSpace(this.Name))
                throw new ArgumentException(DomainValidationsResource.PersonNameEmpty);
        }

        private void ValidateEmail()
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            var isValid = Regex.IsMatch(this.Email, pattern);

            if (!isValid)
                throw new ArgumentException(DomainValidationsResource.EmailInvalid);
        }

        private void ValidateBirth()
        {
            var age = DateTime.Now.Year - this.Birth.Year;
            if (age < 16)
                throw new ArgumentException(DomainValidationsResource.AgeLessThan);
            if (age > 150)
                throw new ArgumentException(DomainValidationsResource.OlderThan);
        }

        public void SetId(int id) => this.Id = id;
    }
}
