namespace SocialNetwork.Infrastructure.Structures
{
    public struct PageQuery
    {
        public int Size { get; set; }
        public int Position { get; set; }
        public int Of { get; set; }
        public int Until { get; set; }
    }
}
