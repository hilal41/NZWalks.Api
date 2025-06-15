using AutoMapper;
using Microsoft.AspNetCore.Http;
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

        public WalksController(IMapper mapper , IwalkRepository iwalkRepository)
        {
            this.mapper = mapper;
            this.iwalkRepository = iwalkRepository;



        }

        [HttpPost]
        public  async Task<IActionResult> Create([FromBody]AddWalksDTO addWalksDTO)
        {
             // map DTO to domain Model

           var   walksDominModel = mapper.Map<Walk>(addWalksDTO);

            await iwalkRepository.CreateAsync(walksDominModel);

            return Ok(mapper.Map <WalkDto>(walksDominModel));
 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {

            var walks = await iwalkRepository.GetWalkasync();

            if (walks == null)
            {
                return NotFound("No walks found.");
            }
            // Map the domain model to DTO

            var walksDTO = mapper.Map<WalkDto>(walks);

            return Ok(walksDTO);










        }








    }

     

}
