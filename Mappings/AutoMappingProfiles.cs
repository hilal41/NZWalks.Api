using AutoMapper;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Domain.DTO.WalksDTOs;

namespace NZWalks.Api.Mappings
{
    public class AutoMappingProfiles : Profile
    {

        public AutoMappingProfiles()
        {
            // mapping domain models between DTOs
            CreateMap<Models.Domain.Region, Models.Domain.DTO.RegionDto>()
                .ReverseMap();
            // mapping domain models between addregionDto 
            CreateMap<Models.Domain.Region, Models.Domain.DTO.AddRegionDto>()
                .ReverseMap();
            CreateMap<Models.Domain.Region, Models.Domain.DTO.updateRegionDto>()
                .ReverseMap();
            CreateMap<AddWalksDTO,Walk >().ReverseMap();
            CreateMap<walkDTo,Walk>().ReverseMap();
        }
    }
}
