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
            CreateMap<AddWalksDTO, Walk>().ReverseMap();
            CreateMap<WalksDTO, Walk>().ReverseMap();
            CreateMap<DifficultyDto, Difficulty>().ReverseMap();


        }
    }
}
