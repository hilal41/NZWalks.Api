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

        //  Create a new walk
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await walksDbContext.walks.AddAsync(walk);
            await walksDbContext.SaveChangesAsync();
            return walk;
        }


        //  Get all walks (this is the method your controller needs)
        public async Task<List<Walk>> GetAllWalksAsync()
        {
            return await walksDbContext.walks.ToListAsync();
        }

        //  (Optional) Get the first walk
        public async Task<Walk?> GetFirstWalkAsync()
        {
            return await walksDbContext.walks.FirstOrDefaultAsync();
        }

        public async Task<List<Walk>> GetAllAsync()

        {
          return   await walksDbContext.walks.Include("Difficulty").Include("Region").ToListAsync();

        }
    }
}
