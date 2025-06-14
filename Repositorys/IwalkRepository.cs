using NZWalks.Api.Models.Domain;

namespace NZWalks.Api.Repositorys
{
    public interface IwalkRepository 
    {

     Task<Walk> CreateAsync(Walk walk);
    }
}
