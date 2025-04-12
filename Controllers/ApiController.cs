using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain.DTO;
using NZWalks.Api.Repositorys;
using Region = NZWalks.Api.Models.Domain.Region;


namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly WalksDbContext DbContext;
        private readonly IMapper mapper;

        public IRegionRepository RegionRepository { get; }

        public ApiController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
        {
            DbContext = dbContext;
            RegionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await RegionRepository.GetAllAsync();
            if (regions == null || regions.Count == 0)
            {
                return NotFound("No regions found.");
            }

            //automapper mapping domain to dto
            var regionDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionDto);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            //automapper mapping a single domain entity to a dto
            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
           
           //automapper mapping dto to domain

            var region = mapper.Map<Region>(addRegionDto);

            region = await RegionRepository.CreateAsync(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] updateRegionDto updateRegionDto)
        {
            // Fetch the region by id
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            // Map the updated data from the DTO to the domain model
            mapper.Map(updateRegionDto, region); // Update region with DTO data

            // Save the updated region to the repository/database
            await RegionRepository.UpdateAsync(id, region); // Ensure your UpdateAsync method takes both id and region

            // Return the updated region as a DTO
            var updatedRegionDto = mapper.Map<RegionDto>(region);
            return Ok(updatedRegionDto); // Return the updated RegionDto
        }




        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            await RegionRepository.DeleteAsync(id, region);
            await DbContext.SaveChangesAsync();


            // Return back region that was deleted

            var regions = new Region
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(regions);
        }



    }
}
