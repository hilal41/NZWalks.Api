using NZWalks.Api.Models.Domain;

public interface IwalkRepository
{
    Task<Walk> CreateAsync(Walk walk);

    Task<List<Walk>> GetAllAsync();
    Task<Walk?> GetByIdAsync(Guid id);
   
    Task<Walk?> UpdateAsync(Guid id, Walk walkDomainModel);
    Task<Walk?> DeleteAsync(Guid id);
}
