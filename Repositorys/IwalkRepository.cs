
using NZWalks.Api.Models.Domain;

public interface IwalkRepository
{
<<<<<<< HEAD
    Task<Walk> CreateAsync(Walk walk);
    Task<List<Walk>> GetAllWalksAsync();
    Task<Walk?> GetFirstWalkAsync();
}       
=======
    public interface IwalkRepository 
    {

     Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
       
    }
}
>>>>>>> 17f82891e952a9c4ddb0a8980264179447c9a2d0
