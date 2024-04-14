using System.ComponentModel.DataAnnotations;

namespace APITraining.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code has to be a min of 3 characters")]
        [MaxLength(3, ErrorMessage = "Code has to be a max of 3 characters")]
        public string Code { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a max of 100 characters")]
        public string Name { get; set; }

        public string? RegionImageUrl { get; set; }
    }
}
/*client cannot create id cos it is a unique identifier, 
 * so it will excluded here.
 *Add some validation to this class to show 
 *what is acceptable from the cleint
 The min and max length for the code is 3*/