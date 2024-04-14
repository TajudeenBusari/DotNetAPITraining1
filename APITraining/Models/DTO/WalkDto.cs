namespace APITraining.Models.DTO
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        /*since walk will have some diffuculty and Region properties
         * The Id's are also present in the RegionDto and DifficultyDto,
         * so we dont need this anymore
        //public Guid DifficultyId { get; set; }
        //public Guid RegionId { get; set; }*/

        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
