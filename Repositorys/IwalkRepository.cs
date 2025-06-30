
using NZWalks.Api.Models.Domain;

public interface IwalkRepository
{
    Task<Walk> CreateAsync(Walk walk);
    Task<List<Walk>> GetAllWalksAsync();       
    Task<Walk?> GetFirstWalkAsync();          
