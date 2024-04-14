using APITraining.CustomActionFilter;
using APITraining.Models.Domain;
using APITraining.Models.DTO;
using APITraining.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APITraining.Controllers
{
    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {   
        //dependency injection
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }


        //CREATE Walk
        //POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> CreateWalk([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            
            {
                //Map AddWalkRequestDto to Walk domain
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
                await walkRepository.CreateWalkAsync(walkDomainModel);

                //Map Domain model to DTO and return it
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            
        }

        //GET Walks
        //GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        [HttpGet]
        public async Task<IActionResult> GetAllWalks([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, 
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
        
        {
           
                
             var walksDomainModel = await walkRepository.GetAllWalksAsync(filterOn, filterQuery, sortBy,
                isAscending ?? true, pageNumber, pageSize);

             //create an exceptiomn
             throw new Exception("This is a new exception");

            //map Domain Model to DTO
             return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
            
        }

        //GET a Walk
        //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetWalkById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetWalkByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }

            //else, Map Domain Model to DTO and return
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        //UPDATE a Walk by Id
        //UPDATE: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> UpdateAWalkById([FromRoute] Guid id, 
             UpdateWalkRequestDto updateWalkRequestDto)
        {
            
            {
                //map DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

                walkDomainModel = await walkRepository.UpadteAWalkByIdAsync(id, walkDomainModel);
                if (walkDomainModel == null)
                {
                    return NotFound();
                }
                //else, Map Domain Model back to DTO
                return Ok(mapper.Map<WalkDto>(walkDomainModel));
            }
            

        }

        //Delete a walk by Id
        //DELETE: /api/Walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteAWalkById([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAWalkByIdAsync(id);
            if(deletedWalkDomainModel == null)
            {
                return NotFound();
            }
            //else, Map Domain Model to DTO, and return
            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));

        }
    }
}






/*create a repo for the walk class
 when we execute the post request, the Guids for difficulties
and Regions are automatically generated. But we will use the ones 
in the data base*/