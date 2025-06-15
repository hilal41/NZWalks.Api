using Microsoft.EntityFrameworkCore;
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

        // Create a new walk
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await walksDbContext.walks.AddAsync(walk);
            await walksDbContext.SaveChangesAsync();
            return walk;
        }

        // Get the first walk
        public async Task<Walk?> GetFirstWalkAsync()
        {
            return await walksDbContext.walks.FirstOrDefaultAsync();
        }
        public async Task<Walk> GetWalkasync()
        {
            // Example implementation: return the first walk or throw if not found
            var walk = await walksDbContext.walks.FirstOrDefaultAsync();
            if (walk == null)
                throw new InvalidOperationException("No walks found.");
            return walk;
        }
    }
}
