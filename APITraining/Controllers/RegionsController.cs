using APITraining.CustomActionFilter;
using APITraining.Data;
using APITraining.Models.Domain;
using APITraining.Models.DTO;
using APITraining.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace APITraining.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDBContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController(NZWalksDBContext dBContext, 
            IRegionRepository regionRepository, 
            IMapper mapper, 
            ILogger<RegionsController> logger)
        {
            this.dbContext = dBContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //create action methods for the controllers
        //GET ALL REGIONS
        //GET: https://locahost:portnumber/api/regions
        [HttpGet]
        //[Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAllRegions()
        {
            
                //when get call is activated this exception is thrown
                //throw new Exception("This is a custom exception");

                //logger.LogInformation("GetAllRegions Action Method was invoked");
                //lets use the db context to talk to the databaseto get all regions
                //1. Get Data from database-Domain model 
                //var regionsDomain = await dbContext.Regions.ToListAsync();

                //Get Data from repository
                var regionsDomain = await regionRepository.GetAllAsync();

                //logger.LogInformation(
                //    $"Finished GetAllRegions request with data: {JsonSerializer.Serialize(regionsDomain)}");

                //2.Map Domain models with Dto
                //var regionsDto = new List<RegionDto>();
                //foreach (var regionDomain in regionsDomain)
                //{
                //    regionsDto.Add(new RegionDto()
                //    {
                //        Id = regionDomain.Id,
                //        Code = regionDomain.Code,
                //        Name = regionDomain.Name,
                //        RegionImageUrl = regionDomain.RegionImageUrl

                //    });
                //}


                //2. map Domain model to DTOs
                var regionsDto = mapper.Map<List<RegionDto>>(regionsDomain);

                //3. Return DTOs back to the client (not domail models)
                return Ok(regionsDto);
            
            
           
        }

        //GET SINGLE REGION(Get Region By Id)
        //GET: https://locahost:portnumber/api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]

        public async Task<IActionResult> GetRegionById([FromRoute] Guid id)
        {
            //only used in the case of id
            //var region = dbContext.Regions.Find(id);

            //can be used with other properties e.g code,name etc
            //1. Get Region DomainModel from data base
            //var regionDomain = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //2. if it is found then, Map/Convert Region Domain Model to Region Dto
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomain.Id,
            //    Code = regionDomain.Code,
            //    Name = regionDomain.Name,
            //    RegionImageUrl = regionDomain.RegionImageUrl
            //};

            //2. Map/Convert Region Domain Model to Region Dto
            var regionDto = mapper.Map<RegionDto>(regionDomain);

            //3. Return DTO back to client
            return Ok(regionDto);
        }

        //POST to create new Region
        //POST: https://locahost:portnumber/api/regions
        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateRegion([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            {
                //1. Map or convert DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Code = addRegionRequestDto.Code,
                //    Name = addRegionRequestDto.Name,
                //    RegionImageUrl = addRegionRequestDto.RegionImageUrl
                //};

                //1. Map or convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                //2. use domain model to create Region and save changes
                //await dbContext.Regions.AddAsync(regionDomainModel);
                //await dbContext.SaveChangesAsync();

                //2. use repo
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                //3. Map Domain model back to DTO
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};
                //3. Map Domain model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return CreatedAtAction(nameof(GetRegionById), new { id = regionDto.Id }, regionDto);
            } 

        }

        //Update Region
        //put: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid id, 
            [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
            {
                //first check if region exist in the database
                //check id now happening in the repository
                //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

                //map DTO to Domain Model
                //var regionDomainModel = new Region
                //{
                //    Code = updateRegionRequestDto.Code,
                //    Name = updateRegionRequestDto.Name,
                //    RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                //};

                //map DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);


                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                ////convert Domain model back to Dto
                //var regionDto = new RegionDto
                //{
                //    Id = regionDomainModel.Id,
                //    Code = regionDomainModel.Code,
                //    Name = regionDomainModel.Name,
                //    RegionImageUrl = regionDomainModel.RegionImageUrl
                //};

                //convert Domain model back to Dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                return Ok(regionDto);
            }
            
        }

        //Delete Region
        //DELETE: https//localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> DeleteRegion([FromRoute] Guid id)
        {
            //first check if the region exists
            //var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if(regionDomainModel == null)
            {
                return NotFound();
            }

            //map Domain model to Dto
            //var regionDto = new RegionDto
            //{
            //    Id = regionDomainModel.Id,
            //    Code = regionDomainModel.Code,
            //    Name = regionDomainModel.Name,
            //    RegionImageUrl = regionDomainModel.RegionImageUrl
            //};

            //map Domain model to Dto
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }
}
