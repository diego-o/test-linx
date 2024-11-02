using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.ViewModel
{
    public struct PostMessageViewModel
    {
        [Required]
        public string Message { get; set; }
    }
}
