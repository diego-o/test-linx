namespace SocialNetwork.Infrastructure.Structures
{
    public struct PageResult
    {
        public int Lines { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public dynamic DataSource { get; set; }
    }
}
