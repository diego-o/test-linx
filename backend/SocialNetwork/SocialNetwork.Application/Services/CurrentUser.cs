using SocialNetwork.Application.Services.Interface;

namespace SocialNetwork.Application.Services
{
    public class CurrentUser : ICurrentUser
    {
        public int IdPersonCurrent { get; set; }
    }
}
