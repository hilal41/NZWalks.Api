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

            return Ok(mapper.Map<AddWalksDTO>(walksDominModel));

        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDominModel = await iwalkRepository.GetAllAsync();

            // map domain model to DTO

            return Ok(mapper.Map<List<WalksDTO>>(walksDominModel));


        }

    }
}
