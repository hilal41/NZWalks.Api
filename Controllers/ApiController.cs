using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.Api.Data;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Domain.DTO;


namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly WalksDbContext DbContext;

        public ApiController(WalksDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var regions = DbContext.regions.ToList();



            var RegionDto = new List <Region>();

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
        public IActionResult GetById([FromRoute] Guid id)
        {
            var region = DbContext.regions.Find(id);

            if (region == null)
            {
                return NotFound();
            }

           var regions = new  RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(region);
        }


        [HttpPost]
        public IActionResult CreateRegion([FromBody] AddRegionDto addRegionDto)
        {
            var region = new Region
            {
                Code = addRegionDto.Code,
                Name = addRegionDto.Name,
                RegionImageUrl = addRegionDto.RegionImageUrl
            };

            DbContext.regions.Add(region);
            DbContext.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, region);
        }


        [HttpPut]

        [Route("{id:guid}")]

        public IActionResult UpdateRegion([FromRoute] Guid id, [FromBody] updateRegionDto updateRegionDto)

        {
           if (updateRegionDto == null)
            { return BadRequest("Invalid region data."); }

           var region = DbContext.regions.Find(id);


            if (region == null) {

                return NotFound (region);
            }

            region.Code = updateRegionDto.Code;
            region.Name = updateRegionDto.Name;
            region.RegionImageUrl = updateRegionDto.RegionImageUrl;


            DbContext.SaveChanges();

            var regions = new Region
            {

                Code = region.Code,

                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl


            };

            return Ok(regions);
        }


        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteRegion([FromRoute] Guid id)
        {
            var region = DbContext.regions.Find(id);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            DbContext.regions.Remove(region);
            DbContext.SaveChanges();

            return NoContent();
        }



    }
}
