namespace SocialNetwork.Api.ViewModel
{
    public struct TokenViewModel
    {
        public string Token { get; set; }
        public int ExpiresIn { get; set; }
        public DateTime Issued { get; set; }
        public DateTime Expires { get; set; }
    }
}
