using APITraining.Models.Domain;
using System.Runtime.InteropServices;

namespace APITraining.Repositories
{
    public interface IRegionRepository
    {
        //create definition for all CRUD methods in the controller

        //GET all regions-->returns a list
        Task<List<Region>> GetAllAsync();

        //GET a single region
        //this can be nullable (?) depending on if we find the region or not
        Task <Region?>GetByIdAsync(Guid id);

        //POST a region
        Task<Region>CreateAsync(Region region);

        //UPDATE a region
        //nullable (?) cos the region may not be present
        Task<Region?>UpdateAsync(Guid id, Region region);

        //DELETE a region
        //nullable (?)
        Task<Region?>DeleteAsync(Guid id);
    }
}
