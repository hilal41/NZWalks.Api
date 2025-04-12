using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositorys;

public class SQLRegionRepository : IRegionRepository
{
    private readonly WalksDbContext dbContext;

    public SQLRegionRepository(WalksDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Region> CreateAsync(Region region)
    {
        await dbContext.regions.AddAsync(region);
        await dbContext.SaveChangesAsync();
        return region;
    }

    public async Task<bool> DeleteAsync(Guid id, Region region)
    {
        var RegionToDelete = await dbContext.regions.FindAsync(id);


        if (region == null)
        {
            return false;
        }
        else
        {
            dbContext.regions.Remove(region);
            await dbContext.SaveChangesAsync();
            return true;
        }
    }

    public async Task<List<Region>> GetAllAsync() 
    {
        return await dbContext.regions.ToListAsync(); 
    }

    public async Task<Region?> GetByIdAsync(Guid id)
    {
       return await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Region?> UpdateAsync(Guid id, Region region)
    {
        var existingRegion = await dbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

        if (existingRegion == null) {

            return null;
        }
        else
        {
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return existingRegion;


        }




    }
}
