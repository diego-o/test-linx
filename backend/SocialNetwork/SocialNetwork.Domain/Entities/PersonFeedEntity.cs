
using SocialNetwork.Domain.Resources;

namespace SocialNetwork.Domain.Entities
{
    public class PersonFeedEntity : EntityBase
    {
        public int IdPerson { get; private set; }
        public string Message { get; private set; }
        public DateTime DateMessage { get; private set; }

        public PersonEntity Person { get; private set; }

        public PersonFeedEntity() { }

        public PersonFeedEntity(int idPerson, string message)
        {
            this.IdPerson = idPerson;
            this.Message = message;
            this.DateMessage = DateTime.Now;

            Validate();
        }

        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Message))
                throw new ArgumentNullException(DomainValidationsResource.FeedMessageNotEpty);

            if (IdPerson <= 0)
                throw new ArgumentException(DomainValidationsResource.FeedIdPersonNotNull);
        }
    }
}
