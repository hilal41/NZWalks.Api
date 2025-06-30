using AutoMapper;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Domain.DTO;
using NZWalks.Api.Models.Domain.DTO.WalksDTOs;

namespace NZWalks.Api.Mappings
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            // Region mappings
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, AddRegionDto>().ReverseMap();
            CreateMap<Region, updateRegionDto>().ReverseMap();

            // Walks mappings
<<<<<<< HEAD
            CreateMap<Walk, WalkDto>().ReverseMap();        
            CreateMap<AddWalksDTO, Walk>().ReverseMap();   
=======
            CreateMap<AddWalksDTO, Walk>().ReverseMap();
            CreateMap<WalksDTO, Walk>().ReverseMap();
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();


>>>>>>> 17f82891e952a9c4ddb0a8980264179447c9a2d0
        }
    }
}
