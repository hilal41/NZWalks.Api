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

        public Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalkTask = walksDbContext.walks.FirstOrDefaultAsync(w => w.Id == id);
            if (existingWalkTask == null)
            {
                return Task.FromResult<Walk?>(null);
            }

            return existingWalkTask.ContinueWith(existingWalk =>
            {
                if (existingWalk.Result == null)
                {
                    return null;
                }

                walksDbContext.walks.Remove(existingWalk.Result);
                walksDbContext.SaveChangesAsync();
                return existingWalk.Result;
            });
        }

        // Get all walks
        public async Task<List<Walk>> GetAllAsync()
        {
            return await walksDbContext.walks
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .ToListAsync();
        }

        // Get by ID
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await walksDbContext.walks
                .Include(w => w.Difficulty)
                .Include(w => w.Region)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        // Update walk
        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await walksDbContext.walks.FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk == null)
                return null;

            // Update fields
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalksImageUrl = walk.WalksImageUrl;
            existingWalk.RegionId = walk.RegionId;
            existingWalk.DifficultyId = walk.DifficultyId;

            await walksDbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
