using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.Api.Models.Domain;
using NZWalks.Api.Models.Domain.DTO.WalksDTOs;
using NZWalks.Api.Repositorys;

namespace NZWalks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IwalkRepository _walkRepository;

        public WalksController(IMapper mapper, IwalkRepository walkRepository)
        {
            _mapper = mapper;
            _walkRepository = walkRepository;
        }

        // POST: api/Walks
        [HttpPost]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalksDTO addWalksDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var walksDomainModel = _mapper.Map<Walk>(addWalksDTO);

            await _walkRepository.CreateAsync(walksDomainModel);

            var walkDTO = _mapper.Map<WalkDto>(walksDomainModel);

            return CreatedAtAction(nameof(CreateWalk), new { id = walkDTO.Id }, walkDTO);
        }

        // GET: api/Walks
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomainModel = await _walkRepository.GetAllAsync();

            if (walksDomainModel == null || !walksDomainModel.Any())
            {
                return NotFound("No walks found.");
            }

            var walksDTO = _mapper.Map<List<WalkDto>>(walksDomainModel);

            return Ok(walksDTO);
        }

        // GET: api/Walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalksById([FromRoute] Guid id)
        {
            var walkDomainModel = await _walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound($"No walk found with ID: {id}");
            }

            var walkDTO = _mapper.Map<WalkDto>(walkDomainModel);
            return Ok(walkDTO);
        }

        // PUT: api/Walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateWalkById([FromRoute] Guid id, [FromBody] UpdateWalkDto updateWalkDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var walkDomainModel = _mapper.Map<Walk>(updateWalkDto);

            var updatedWalk = await _walkRepository.UpdateAsync(id, walkDomainModel);

            if (updatedWalk == null)
            {
                return NotFound($"No walk found with ID: {id}");
            }

            var walkDto = _mapper.Map<WalkDto>(updatedWalk);
            return Ok(walkDto);
        }

        // DELETE: api/Walks/{id}
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteWalkById(Guid id)
        {
            var walk = await _walkRepository.GetByIdAsync(id);
            if (walk == null)
            {
                return NotFound(new { Message = $"No walk found with ID: {id}" });
            }

            await _walkRepository.DeleteAsync(id);

            return Ok(new { Message = "Walk deleted successfully." });
        }










    }
}
