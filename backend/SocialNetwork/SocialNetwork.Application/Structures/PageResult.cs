namespace SocialNetwork.Application.Structures
{
    public struct PageResult
    {
        public int Lines { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; }
        public int Total { get; set; }
        public dynamic DataSource { get; set; }
    }
}
