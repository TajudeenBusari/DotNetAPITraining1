using APITraining.Data;
using APITraining.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace APITraining.Repositories
{
    public class SQLRegionRepository : IRegionRepository
       
    {
        private readonly NZWalksDBContext dBContext;
        public SQLRegionRepository(NZWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        //POST
        public async Task<Region> CreateAsync(Region region)
        {
           await dBContext.Regions.AddAsync(region);
           await dBContext.SaveChangesAsync();
            return region;
        }

        //DELETE
        public async Task<Region?> DeleteAsync(Guid id)
        {
           var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            dBContext.Regions.Remove(existingRegion);
            await dBContext.SaveChangesAsync();
            return existingRegion;
        }

        //GET ALL
        public async Task<List<Region>> GetAllAsync()
        {
           return await dBContext.Regions.ToListAsync();
        }

        //GET A SINGLE
        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x =>x.Id == id);
            if (existingRegion == null) 
            {
                return null;
            }
            //else
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dBContext.SaveChangesAsync();
            return existingRegion;
        }
    }
}


//this class implements the IRepository class
//we will make use of the dbcontext here instead of using it in the controller
//inject the dbContext in this class
//inject the IRepository and its implementation in the program.cs (build.service)