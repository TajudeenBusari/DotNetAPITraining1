using APITraining.Models.Domain;

namespace APITraining.Repositories
{
   /* public class InMemoryRegionRepository : IRegionRepository
    {
        public async Task<List<Region>> GetAllsync()
        {
            return new List<Region>
            {
                new Region()
                {
                    Id = Guid.NewGuid(),
                    Code = "TJB",
                    Name = "Tajudeen Busari Region"
                }

            };
        }
    }*/
}

//this is just for reference purpose, I am not using the class
/*This class is another type of 
 * repository implementaion class that is using InMemory database
 * just like the SQLRegionRepository that is using the SQL database
 * You will just have to change the injection to the InMemory Repo in the program.cs
 This is just to show how easy to switch database with this kind of 
API architectural arrangement*/