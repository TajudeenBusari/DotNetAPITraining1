using APITraining.Models.Domain;

namespace APITraining.Repositories
{
    public interface IWalkRepository
    {
       Task<Walk> CreateWalkAsync(Walk walk);
        //add the query params here
       Task <List<Walk>>GetAllWalksAsync(string? filterOn =null, string? filterQuery =null, 
           string? sortBy = null, bool isAscending = true, int pageNumber =1, int pageSize = 1000);
       Task <Walk?>GetWalkByIdAsync(Guid id);
        Task <Walk?>UpadteAWalkByIdAsync(Guid id, Walk walk);
        Task <Walk?>DeleteAWalkByIdAsync(Guid id);


    }

}
/*repository is always dealing with the domain model*/