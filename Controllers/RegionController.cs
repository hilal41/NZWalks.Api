using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.CustomActionFilter;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain.DTO;
using NZWalks.Api.Repositorys;
using Region = NZWalks.Api.Models.Domain.Region;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly WalksDbContext DbContext;
        private readonly IMapper mapper;
        private readonly IRegionRepository RegionRepository;

        public RegionController(WalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper)
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
                return NotFound("No regions found.");

            var regionDto = mapper.Map<List<RegionDto>>(regions);
            return Ok(regionDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
                return NotFound("Region not found.");

            var regionDto = mapper.Map<RegionDto>(region);
            return Ok(regionDto);
        }

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
            var region = mapper.Map<Region>(addRegionDto);
            region = await RegionRepository.CreateAsync(region);
            var regionDto = mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        [HttpPut("{id:guid}")]
        [ValidateModel]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] updateRegionDto updateRegionDto)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
                return NotFound("Region not found.");

            mapper.Map(updateRegionDto, region);
            await RegionRepository.UpdateAsync(id, region);

            var updatedRegionDto = mapper.Map<RegionDto>(region);
            return Ok(updatedRegionDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
                return NotFound("Region not found.");

            await RegionRepository.DeleteAsync(id, region);

            return Ok(new { message = "Region deleted successfully." });
        }

    }
}
