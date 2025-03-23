using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Domain.DTO;
using NZWalks.Api.Repositorys;


namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly WalksDbContext DbContext;

        public IRegionRepository RegionRepository { get; }

        public ApiController(WalksDbContext dbContext , IRegionRepository regionRepository)
        {
            DbContext = dbContext;
            RegionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await RegionRepository.GetAllAsync();


            var RegionDto = new List<Region>();
            foreach (var region in regions)
            {
                RegionDto.Add(new Region
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }


            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await RegionRepository.GetByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regions = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            

            return Ok(region);
        }


        [HttpPost]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
            var region = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                RegionImageUrl = addRegionDto.RegionImageUrl
            };


            region = await RegionRepository.CreateAsync(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, [FromBody] updateRegionDto updateRegionDto)

        {
            var region = new Region();
            {


                region.Id = id;
                region.Code = updateRegionDto.Code;
                region.Name = updateRegionDto.Name;
                region.RegionImageUrl = updateRegionDto.RegionImageUrl;
            }



            if (updateRegionDto == null)
            {
                return BadRequest("Invalid region data.");
            }

            region = await RegionRepository.UpdateAsync(id, region);


            if (region == null)
            {

                return NotFound(region);
            }

            region.Code = updateRegionDto.Code;
            region.Name = updateRegionDto.Name;
            region.RegionImageUrl = updateRegionDto.RegionImageUrl;


            DbContext.SaveChanges();

            var regions = new Region
            {
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl,
            };

            return Ok(updateRegionDto);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public  async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            var region = await DbContext.regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

              DbContext.regions.Remove(region);
              DbContext.SaveChanges();

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
