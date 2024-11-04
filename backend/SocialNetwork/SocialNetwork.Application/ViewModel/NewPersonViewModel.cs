using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Application.ViewModel
{
    public class NewPersonViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime Birth { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
