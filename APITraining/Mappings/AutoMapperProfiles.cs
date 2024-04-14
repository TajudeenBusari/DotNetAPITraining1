using APITraining.Models.Domain;
using APITraining.Models.DTO;
using AutoMapper;

namespace APITraining.Mappings
{
    public class AutoMapperProfiles: Profile
    {
        //create a constructor. press-->ctor,then enter
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<AddRegionRequestDto, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
            CreateMap<AddWalkRequestDto, Walk>().ReverseMap();
            CreateMap<Walk,  WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalkRequestDto, Walk>().ReverseMap();



        }

    }
}
/*SINCE all poperties in both are same, 
 * we dont have to use the .ForMember...
 Inject the automapper by building in service 
in the program.cs file, so the application can use it when 
it starts*/