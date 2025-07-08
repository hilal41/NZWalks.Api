//using AutoMapper;
//using NZWalks.Api.Models.Domain;
//using NZWalks.Api.Models.Domain.DTO;
//using NZWalks.Api.Models.Domain.DTO.WalksDTOs;

//namespace NZWalks.Api.Mappings
//{
//    public class AutoMappingProfiles : Profile
//    {
//        public AutoMappingProfiles()
//        {
//            // Region mappings
//            CreateMap<Region, RegionDto>().ReverseMap();
//            CreateMap<Region, AddRegionDto>().ReverseMap();
//            CreateMap<Region, updateRegionDto>().ReverseMap();

//            // Walks mappings

//            CreateMap<Walk, WalkDto>().ReverseMap();        
//            CreateMap<AddWalksDTO, Walk>().ReverseMap();   
//            CreateMap<AddWalksDTO, Walk>().ReverseMap();
//            CreateMap<WalksDTO, Walk>().ReverseMap();
//            CreateMap<DifficultyDto, Difficulty>().ReverseMap();
//            CreateMap<UpdateWalkDto, UpdateWalk>().ReverseMap();





//        }
//    }
//}

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

            // Difficulty mappings
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();

            // Walk mappings
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, AddWalksDTO>().ReverseMap();
            CreateMap<Walk, UpdateWalkDto>().ReverseMap();
        }
    }
}
