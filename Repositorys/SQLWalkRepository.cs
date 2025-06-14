using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositorys
{
    public class SQLWalkRepository : IwalkRepository
    {
        private readonly WalksDbContext walksDbContext;

        public SQLWalkRepository(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await walksDbContext.walks.AddAsync(walk);
            await walksDbContext.SaveChangesAsync();
            return walk;
        }
    }
}
