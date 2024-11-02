namespace SocialNetwork.Infrastructure.Context.Interfaces
{
    public interface IDbContext
    {
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
