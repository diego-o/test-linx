using SocialNetwork.Api.Services.Interface;

namespace SocialNetwork.Api.Services
{
    public class CurrentUser : ICurrentUser
    {
        public int IdPersonCurrent { get; set; }
    }
}
