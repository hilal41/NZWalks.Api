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
        private readonly IMapper mapper;
        private readonly IwalkRepository iwalkRepository;

        public WalksController(IMapper mapper, IwalkRepository iwalkRepository)
        {
            this.mapper = mapper;
            this.iwalkRepository = iwalkRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalksDTO addWalksDTO)
        {
            // map DTO to domain Model

            var walksDominModel = mapper.Map<Walk>(addWalksDTO);

            await iwalkRepository.CreateAsync(walksDominModel);

<<<<<<< HEAD
            return Ok(mapper.Map <WalkDto>(walksDominModel));
 
        } 
=======
            return Ok(mapper.Map<AddWalksDTO>(walksDominModel));

        }

>>>>>>> 17f82891e952a9c4ddb0a8980264179447c9a2d0
        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDominModel = await iwalkRepository.GetAllAsync();

<<<<<<< HEAD
            var walks = await iwalkRepository.GetAllWalksAsync();

            if (walks == null)
            {
                return NotFound("No walks found.");
            }
            // Map the domain model to DTO
            // This is where the AutoMapper comes into play
            var walksDTO = mapper.Map<List<WalkDto>>(walks);

            return Ok(walksDTO);
=======
            // map domain model to DTO

            return Ok(mapper.Map<List<WalksDTO>>(walksDominModel));

>>>>>>> 17f82891e952a9c4ddb0a8980264179447c9a2d0

        }

    }
}
